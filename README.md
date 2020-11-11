# Music Util


Music Util is a tool I built to explore the connection between math and music.
It can be used as a backend tool for calculating maths in music easily and using notes

## New Features!

  - Create and Play advanced backing tracks using conventional chord symbols (c,cm,c7,cmaj7,cm7,cm7b5)
  - Improvise over a scale
  - Adaptable BPM 


You can also:
  - Play individual notes of all octaves
  - Create your own compositions

## Development


 ##### Music Util uses three important classes
 - SoundPlayer (`static` `state-machine` soundplayer and an example of implementation)
 - SoundManager (`static` main 'engine' backend math of music )
 - Scale (class that maybe I'll remove which holds information about a scale)
  
Examples
```sh
> Scale myScale = new Scale("c", Scale.ScaleType.Major);
> SoundPlayer.currentScale = myScale;
> SoundPlayer.bpm = 120;
> SoundPlayer.Play();

```
This code will generate randomized improvisation at `120` beats per minute over the scale of C Major.


```sh
> SoundPlayer.bpm = 100;
> SoundPlayer.LoopTrack(new string[]{"c","am","f","g"}, 3);
```
This code will generate a backing track using the chords from the string array (c major, a minor, f major, g major) 
with `3` beats in every bar at `100` bpm

```sh
> SoundPlayer.bpm = 120;
> SoundPlayer.LoopTrack(SoundManager.AutumnLeaves);
```
This code is using some of SoundManager's existing soundtracks (Autumn Leaves) at a bpm of `120`.

For further explanation there's documentation on every function ;)
Thank you for using my tool and contributing!

## License
[MIT](https://choosealicense.com/licenses/mit/)

