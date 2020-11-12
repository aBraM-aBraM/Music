# Music Util


Music Util is a tool I built to explore the connection between math and music.
It can be used as a backend tool for calculating maths in music easily and using notes

## Features

  - Create and Play advanced backing tracks using conventional chord symbols (c,cm,c7,cmaj7,cm7,cm7b5)
  - Improvise over a scale
  - Overall great simplicity  


You can also:
  - Play individual notes of all octaves
  - Create your own compositions

## Development


 ##### Music Util uses two important classes
 - SoundPlayer (`static` soundplayer and an example of implementation)
 - SoundManager (`static` main 'engine' backend math of music )
 
  
 ##### Examples:

Scale Iteration Playing
```sh
> int[] myScale = SoundManager.GetScaleNotesFreq("c", SoundManager.ScaleType.MAJOR);
> SoundPlayer.Play(scale);

```
This code will play every note of the C Major Scale.


Improvisation
```sh
> int[] myScale = SoundManager.GetScaleNotesFreq("c", SoundManager.ScaleType.MAJOR);
> SoundPlayer.Improv(scale, 120);

```
This code will generate randomized improvisation at `120` beats per minute over the scale of C Major.


Custom Backing Tracks
```sh
> SoundPlayer.LoopTrack(new string[]{"c","am","f","g"}, 100, 3);
```
This code will generate a backing track using the chords from the string array (c major, a minor, f major, g major) 
with `3` beats in every bar at `100` bpm


Using Existing Backing Tracks
```sh
> SoundPlayer.LoopTrack(SoundManager.AutumnLeaves, 120);
```
This code is using some of SoundManager's existing soundtracks (Autumn Leaves) at a bpm of `120`.


For further explanation there's documentation on every function ;)
Thank you for using my tool and contributing!

## License
[MIT](https://choosealicense.com/licenses/mit/)

