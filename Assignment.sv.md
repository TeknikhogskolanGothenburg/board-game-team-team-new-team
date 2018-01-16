# Brädspel

Uppgiften skall lösas i teams på 3 till 4 studenter.

Uppgiften består av två delar, en programmeringsdel och en dokumentationsdel. 

Allt ni gör skall göras i ert GitHub repo (båda kod och dokumentation), som ligger på ert Team. Ni skall använda en ["commit tidigt och ofta"](https://blog.codinghorror.com/check-in-early-check-in-often/) ([1](https://sethrobertson.github.io/GitBestPractices/)) strategi, såklart bör ni endast commita kod och dokumentation som kan kompileras.

# Programmering
I detta projekt ska ni implementera ett brädspel, ni får själv välja vilket, men där finns ett Fia bräde (Ludo på engelska) i mappen Content som ni kan använda som grund (CSS och HTML). Den är enklast uppgift är ett spel vart man turas om att spela.

Spelet ska implanteras som ett tomt ASP.NET MVC projekt (inte .NET Core) och Razor i kombination med HTML ska användas till att presentera spelet. 
Eran solution och all kod ska ligga i mappen Src, varje team har bara en kodbas!!

Det går bra om alla igångvarande spel bara lever i minnet, så där är inget krav på att ni skall spara staten i databas eller på disk.

Det går också bra om användarna själv ska uppdatera sidan (tycka F5) för att kunna följa med i spelet.

Spelet skall bara kunna köra på eran lokal dator (localhost).

Start sidan finns på root URLen. Ex: http://localhost/

Varje spel har sin egen unika URL. Ex: http://localhost/123456789

## Grundtanken
Spelet ska vara en websida vart man går in som spellera.

När man som ny spellera kommer in på sidan ska man kunna välja att starta ett spel eller vara del va ett eksisterende spel, alla eksisterende öppna spel visas som en lista. 

Om man vill starta ett nytt spel ska man ange sin epost adress och hur många spelleror (min 2 och max 4 för Fia) som ska vara i spelet. Om man vill vara med i ett öppet spel ett i listan och anger sin epost adress och kommer sen in på spelet.

Om man redan är en del av ett spel hoppar automatisk in på spelet och ser därför aldrig första sidan.

När alla spelleror är inne i spelet (angivit med antalet av spellera) stängs spelet och det startar. Alla spelleror får ett mail om att spelet starter och första spelare får en epost om att det är hens rond.

En spelar starter sin rond med att klicka på en knap som rullar tärningen, och väljer efter detta brickan som hen önskar att flytta.

När en spelar avslutar sin rond, sickas en epost till den nästa så att hen kan gå in och flytta på sin bricka.

När en spellera vinner spelet ska alla spellera få ett mail om att spelet är slut och spelet tas bort så att det inte finns mer.

## Spelmotor (GameEngine)
Spelmotorn styra alla regler i spelet och kollar t.ex. om en bricka får flyttas, om en spelar har vunnit, den initiala uppställning av alla brickor på brädet, vilken spelar som är den nästa, hur en tärning ska bete sig, etc.

Implementera spelmotorn i ett separat klass bibliotek, implementationen skall följa SOLID principerna, så långt det går.

En instans av spelmotorn innehåller staten av ett helt spel, det skall vara möjligt att initialisera spelet med en given state.

Ett enhetstest (Unit Test) projekt skall skåpas, och logiken i spelet ska testas med enhetstestar.

# Dokumentation
Dokumentation ska skrivas som Markdown i mappen DocsSrc, ni väljer själv om ni vill skriva på svenska eller engelska.

Skriv user stories (i mappen DocsSrc\userstories), och starta inte koda något innan in har skrivet minst 3 user stories, men se hela tiden till att lägga till fler user stories.

Beskriv arkitekturen av eran applikation (i mappen DocsSrc\architecture).

Om ni använder någon externa källor (båda kod och annat) ange dom i dokumentationen.