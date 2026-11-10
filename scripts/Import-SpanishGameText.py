"""Turn the decompiled WildfrostSpanish.cs into the mod's Spanish game-text tables.

    python Import-SpanishGameText.py WildfrostSpanish.cs GameTranslations.Spanish.cs
    python Import-SpanishGameText.py --fix GameTranslations.Spanish.cs

The Workshop translation drops some accents and opening marks, which a screen
reader then mispronounces. Both modes apply the corrections below; --fix
re-applies them to an already generated file.
"""
import re, sys

# Words missing their accent, matched whole and with case kept ("Talisman" -> "Talismán")
ACCENT_FIXES = {
    'aguijon': 'aguijón', 'alquitran': 'alquitrán', 'arandano': 'arándano',
    'corazon': 'corazón', 'dragon': 'dragón', 'durian': 'durián',
    'frenetica': 'frenética', 'fungico': 'fúngico', 'jabalies': 'jabalíes',
    'jarron': 'jarrón', 'liquido': 'líquido', 'macaquin': 'macaquín',
    'machetin': 'machetín', 'magmatico': 'magmático', 'mama': 'mamá',
    'maquina': 'máquina', 'mascara': 'máscara', 'niveo': 'níveo',
    'pajaro': 'pájaro', 'portatil': 'portátil', 'punteria': 'puntería',
    'relojeria': 'relojería', 'super': 'súper', 'taladrin': 'taladrín',
    'talisman': 'talismán', 'terron': 'terrón', 'tigrin': 'tigrín',
    'tootocordeon': 'tootocordeón', 'totem': 'tótem', 'unicamente': 'únicamente',
}

# Fixes that depend on the sentence: interrogatives, "estás", typos and
# missing opening exclamation marks
PHRASE_FIXES = [
    ('¡Como está el', '¡Cómo está el'),
    ('¡Cuantos más', '¡Cuántos más'),
    ('¡Estas casi sin cartas!', '¡Estás casi sin cartas!'),
    ('<Camapana>', '<Campana>'),
    ('"<{0}> está listo para salir!', '"¡<{0}> está listo para salir!'),
    ('"Recuperado de las lesiones!', '"¡Recuperado de las lesiones!'),
    ('"[{0}] fue herido en batalla!', '"¡[{0}] fue herido en batalla!'),
    ('"Algunos de tus [Compañeros] fueron heridos en batalla!', '"¡Algunos de tus [Compañeros] fueron heridos en batalla!'),
    ('"Arrastra [{0}] frente a tu', '"¡Arrastra [{0}] frente a tu'),
    ('<size=0.3>Recuerda, puedes curar', '<size=0.3>¡Recuerda, puedes curar'),
    (r'\n\nActualmente, el ataque de [{0}]', r'\n\n¡Actualmente, el ataque de [{0}]'),
    ('<size=0.35>[{0}] tiene un efecto de [Reacción]', '<size=0.35>¡[{0}] tiene un efecto de [Reacción]'),
    ('<size=0.35>[{0}] regresa [Herido]', '<size=0.35>¡[{0}] regresa [Herido]'),
    ('¡Hola! <Zoe> aquí', '¡Hola! ¡<Zoe> aquí'),
    (r'\n\nVuelve aquí después de cada partida', r'\n\n¡Vuelve aquí después de cada partida'),
    ('<#ff0>2 Nuevos Enemigos!', '<#ff0>¡2 Nuevos Enemigos!'),
    ('hielo, que me dices?', 'hielo, qué me dices?'),
    ("<keyword=snow>'ado", '<keyword=snow>'),
    ('  <keyword=', ' <keyword='),
]

# Status effects show as nouns ("Nieve", "Hongo"), so "algo es Nieve" has to
# read "algo es afectado por Nieve". "sacrificed" shows as an adjective and
# is left alone.
_status_re = re.compile(r'\b(es|sea|ser|está|estar) +(<keyword=(?:snow|shroom|shell|spice|juice)>)')

# Entries whose translation is wrong as a whole, by key
KEY_FIXES = {
    # The translation copied the shell line and kept the wrong keyword
    '"to_snowed_targets"': '"{0} a los objetivos con <keyword=snow>"',
}

_accent_re = re.compile(r'\b(' + '|'.join(ACCENT_FIXES) + r')\b', re.I)


def fix_spanish(key, value):
    """Correct one entry; key and value are quoted C# string literals."""
    value = KEY_FIXES.get(key, value)
    for old, new in PHRASE_FIXES:
        value = value.replace(old, new)
    value = _status_re.sub(r'\1 afectado por \2', value)

    def accent(m):
        w = m.group(0)
        rep = ACCENT_FIXES[w.lower()]
        if w.isupper() and len(w) > 1:
            return rep.upper()
        return rep[0].upper() + rep[1:] if w[0].isupper() else rep
    return _accent_re.sub(accent, value)


if sys.argv[1] == '--fix':
    path = sys.argv[2]
    generated = open(path, encoding='utf-8').read()
    fixed = re.sub(r'(t\.AddEntry\()("(?:[^"\\]|\\.)*")(, )("(?:[^"\\]|\\.)*")(\);)',
                   lambda m: m.group(1) + m.group(2) + m.group(3) + fix_spanish(m.group(2), m.group(4)) + m.group(5),
                   generated)
    open(path, 'w', encoding='utf-8', newline='\n').write(fixed)
    print('fixed', sum(a != b for a, b in zip(generated.split('\n'), fixed.split('\n'))), 'lines')
    sys.exit(0)

src, dst = sys.argv[1], sys.argv[2]
text = open(src, encoding='utf-8').read()

method_re = re.compile(r'private void (Set(\w+)Localizations)\(\)\s*\{(.*?)\n\t\}', re.S)
coll_re = re.compile(r'GetCollection\("([^"]+)", ModLanguage\)')
entry_re = re.compile(r'\.AddEntry\(("(?:[^"\\]|\\.)*"), ("(?:[^"\\]|\\.)*")\);')

methods = []
total = 0
for m in method_re.finditer(text):
    name, body = m.group(2), m.group(3)
    c = coll_re.search(body)
    if not c:
        continue
    entries = entry_re.findall(body)
    # every AddEntry line in the body must have been captured
    assert body.count('.AddEntry(') == len(entries), name
    total += len(entries)
    methods.append((name, c.group(1), entries))

out = []
out.append('// <auto-generated>')
out.append('// Spanish text for the game itself (cards, menus, tutorials, journal),')
out.append('// from "Lozalizacion al Espanol" by Bombixfm and Naufrago (Steam Workshop')
out.append('// item 3303667067), bundled so players need no second mod. Regenerate with')
out.append('// scripts/Import-SpanishGameText.py rather than editing by hand.')
out.append('// </auto-generated>')
out.append('')
out.append('namespace WildfrostAccessibility')
out.append('{')
out.append('    public static partial class GameTranslations')
out.append('    {')
out.append('        /// <summary>Every Spanish string table, as (table collection, fill method).</summary>')
out.append('        private static readonly (string Table, System.Action<UnityEngine.Localization.Tables.StringTable> Fill)[] SpanishTables =')
out.append('        {')
for name, coll, _ in methods:
    out.append(f'            ("{coll}", Spanish{name}),')
out.append('        };')
for name, coll, entries in methods:
    out.append('')
    out.append(f'        private static void Spanish{name}(UnityEngine.Localization.Tables.StringTable t)')
    out.append('        {')
    for k, v in entries:
        out.append(f'            t.AddEntry({k}, {fix_spanish(k, v)});')
    out.append('        }')
out.append('    }')
out.append('}')
open(dst, 'w', encoding='utf-8', newline='\n').write('\n'.join(out) + '\n')
print(len(methods), 'tables,', total, 'entries')
for name, coll, e in methods:
    print(' ', coll, len(e))
