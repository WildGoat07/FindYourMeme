# FindYourMeme

Best spicy meme finder ever 👌

Basically, a small window made to search for a meme then copy its image link. That's it.

Base window :

![image](https://user-images.githubusercontent.com/30344403/132132038-9fc67718-d309-4527-a37f-852b08499cef.png)

You can search memes :

![image](https://user-images.githubusercontent.com/30344403/132132053-705ed1aa-78d0-4dc7-8d8d-2cb67c691e5a.png)

Hovering the mouse over an image displays more infos, and for gifs there is a small indication on the bottom right :

![image](https://user-images.githubusercontent.com/30344403/132132070-7a96569a-8972-4b27-8f50-c09d59b7ad93.png)

## How it works

It uses the Google API, with a [programmable search engine](https://cse.google.com/cse?cx=2bad711db3c3108e7).
The results are only from [knowyourmeme.com](https://knowyourmeme.com/) for the spiciest, the dankest memes possible.

## Pre building

Before building the project, you have to create a special file, `Key.txt`
at the root of the project with the Google Cloud Plateform API Key, with the right to do a custom search. Then you can restore/build.
