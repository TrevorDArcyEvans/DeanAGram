# Dean-A-Gram - The Anagram Solver

According to [Wikipedia](https://en.wikipedia.org/wiki/Anagram):

    "An anagram is a word or phrase formed by rearranging the letters of a
    different word or phrase, typically using all the original letters exactly
    once."

## Examples

<details>
    <summary>Satrical</summary>

### Satrical

* "New York Times" = "monkeys write"
* "Church of Scientology" = "rich-chosen goofy cult"
* "McDonald's restaurants" = "Uncle Sam's standard rot"

</details>

<details>
    <summary>Synonyms</summary>

### Synonyms

* "evil" = "vile"
* "a gentleman" = "elegant man"
* "silent" = "listen"
* "eleven plus two" = "twelve plus one"
* "angered" = "enraged"
* "the eyes" = "they see"

</details>

<details>
    <summary>Antonyms</summary>

### Antonyms aka antigrams

* "restful" = "fluster"
* "cheater" = "teacher"
* "funeral" = "real fun"
* "adultery" = "true lady"
* "forty five" = "over fifty"
* "Santa" = "Satan"

</details>

<details>
    <summary>Proper nouns</summary>

### Proper nouns or names

* "William Shakespeare" = "I am a weakish speller"
* "Madam Curie" = "Radium came"
* "George Bush" = "He bugs Gore"
* "Tom Marvolo Riddle" = "I am Lord Voldemort"
* "Jim Morrison" = "Mr Mojo Risin"[5]
* "The Morse code" = "Here come dots"

</details>

<details>
    <summary>Compund words</summary>

### [Compund words](https://en.wikipedia.org/wiki/English_compound)

* household
* blackbird
* notebook
* sunflower
* bedroom
* bandstand
* starfish
* sunflower
* girlfriend
* policeman
* football
* sunglasses
* wildflower
* blackboard
* breakwater
* underworld
* waterproof
* bittersweet
* drive-through
* over-ripe
* nosebleed
* shortcoming
* buy-bust
* undercut
* love-in
* once-over
* takeout
* forever

</details>

<details>
    <summary>Alternate solutions</summary>

### Alternate solutions

* a lamp <--> a palm
* coat <--> a cot
* tub <--> but
* shit <--> this

</details>

<details>
    <summary>Multiple solutions</summary>

## Multiple solutions

* "Tom Marvolo Lot Riddle"
    * "I am Lord Lot Voldemort"
    * "mail to Lord Voldemort"

</details>

## Prerequisites

<details>

### Required
* git
* Dotnet Core 9 or higher

### Optional
* [DrawIO](https://www.drawio.com/) (for updating diagrams)

</details>

## Getting started

<details>

```bash
# clone repository
git clone https://github.com/TrevorDArcyEvans/dean_a_gram.git

# build code
cd dean_a_gram/src
dotnet restore
dotnet build

# run tests
dotnet test
```

</details>

## Usage

<details>

```bash
# convert word list to a word map
./DeanAGram.Utils [path to word list file]

# example
./DeanAGram.Utils /home/trevorde/dev/anagram-solver/top-english-wordlists/top_english_adps_lower_500.txt

# output
Processing:  /home/trevorde/dev/anagram-solver/top-english-wordlists/top_english_adps_lower_500.txt
  --> /home/trevorde/dev/anagram-solver/top-english-wordlists/top_english_adps_lower_500.json in 2774 ms


# solve an anagram
./DeanAGram.CLI [Path to JSON word file] [Anagram text without spaces]

# example
./DeanAGram.CLI /home/trevorde/dev/anagram-solver/top-english-wordlists/top_english_adps_lower_500.json anklesdomoms

# output
smoked salmon 
```

</details>

## How it works

<details>

<details>
    <summary>Overview</summary>

![Overview](media/dean-a-gram-overview.png)

</details>

<details>
    <summary>Unsuccessful solution</summary>

![Overview](media/dean-a-gram-unsuccessful.png)

</details>

<details>
    <summary>Successful solution</summary>

![Overview](media/dean-a-gram-successful.png)

</details>

</details>

## Word lists

* [English words](https://github.com/dwyl/english-words.git)
* [Top English word lists](https://github.com/david47k/top-english-wordlists.git)

## Discussion

<details>
    <summary>Sample output</summary>

```bash
$ ./DeanAGram.CLI test.json smokedsalmon
Processing:
  test.json
  "smokedsalmon"

  and look m me s s 
  and look m me ss 
  and em look m s s 
  and em look m ss 
  and look mme s s 
  and look mme ss 
  and look m m s se 
  and look mm s se 
  and es look m m s 
  and es look mm s 
  and look m m ses 
  and look mm ses 
  dna look m me s s 
  dna look m me ss 
  dna em look m s s 
  dna em look m ss 
  dna look mme s s 
  dna look mme ss 
  dna look m m s se 
  dna look mm s se 
  dna es look m m s 
  dna es look mm s 
  dna look m m ses 
  dna look mm ses 
  dan look m me s s 
  dan look m me ss 
  dan em look m s s 
  dan em look m ss 
  dan look mme s s 
  dan look mme ss 
  dan look m m s se 
  dan look mm s se 
  dan es look m m s 
  dan es look mm s 
  dan look m m ses 
  dan look mm ses 
  a end look m m s s 
  a end look mm s s 
  a den look m m s s 
  a den look mm s s 
  a edn look m m s s 
  a edn look mm s s 
  a look m m ned s s 
  a look mm ned s s 
  a end look m m ss 
  a end look mm ss 
  a den look m m ss 
  a den look mm ss 
  a edn look m m ss 
  a edn look mm ss 
  a look m m ned ss 
  a look mm ned ss 
  as end look m m s 
  as end look mm s 
  as den look m m s 
  as den look mm s 
  as edn look m m s 
  as edn look mm s 
  as look m m ned s 
  as look mm ned s 
  ass end look m m 
  ass end look mm 
  ass den look m m 
  ass den look mm 
  ass edn look m m 
  ass edn look mm 
  ass look m m ned 
  ass look mm ned 
  an de look m m s s 
  an de look mm s s 
  an ed look m m s s 
  an ed look mm s s 
  an de look m m ss 
  an de look mm ss 
  an ed look m m ss 
  an ed look mm ss 
  de look m m na s s 
  de look mm na s s 
  ed look m m na s s 
  ed look mm na s s 
  de look m m na ss 
  de look mm na ss 
  ed look m m na ss 
  ed look mm na ss 
  de look m man s s 
  ed look m man s s 
  de look m nam s s 
  ed look m nam s s 
  de look m man ss 
  ed look m man ss 
  de look m nam ss 
  ed look m nam ss 
  salmon smoked 
Found 93 solutions in 7381 ms
```

</details>

<details>

The sample output was from a small wordlist of ~5000 words.  As may be seen, there are a lot
of 'spurious words' eg
* m
* mm
* s
* ss
* ned
* de
* ed
* edn
* es
* em
etc

AFAIK, these 'words' are not in common, or even any, usage.  This has the effect of generating
a great many extra 'paths' which lead to no solutions.  This greatly increases runtime and
memory consumption.  The fix is to 'curate' the word lists by removing these non-words.

</details>

## Further work
* Performance!  Performance!  Performance!
  * increase speed
  * reduce memory consumption
* curate word lists to remove spurious words

## Further information
* Websites
  * [Anagrammer](https://www.wordplays.com/anagrammer/)
  * [Anagram Solver](https://www.wordplays.com/anagram-solver)
* Code on GitHub
  * [anagram](https://github.com/gwerners/anagram.git)
  * [Anagram](https://github.com/XyLoNaMiyX/Anagram.git)
  * [Anagram-Solver](https://github.com/pratikshekhar/Anagram-Solver.git)

