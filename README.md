# Graph3d
is a force driven 3D graph visualization tool that automatically clusters strongly connected nodes and separates weakly conntected areas. I is created with Unity3d 5.5.4.

![rotate and force demo gif](https://github.com/JanMMeyer/G3DDemos/blob/master/g3ddemorotatesmall.gif)
![select demo gif](https://github.com/JanMMeyer/G3DDemos/blob/master/g3ddemoselectsmall.gif)

<b>The project is currently in alpha stage.</b>

The "Assets" folder contains only the Graph3d-Assets. Graph3d uses the [crosstales filebrowser plugin](https://goo.gl/GCmzrU) which needs to be istalled separately via the asset-store to build the project in Unity3d. The C# source code hides in Assets/scripts.

# Installation and Usage

<b>On Windows:</b>
Download and unzip the [latest release](https://github.com/JanMMeyer/Graph3d/releases/latest). It's a standalone build, so just start the G3D.exe and enjoy!

<b>Loading graph data:</b>

To load a Graph, use the "Open"-Button and select a folder containing "Nodes.csv" and "Edges.csv".
The Build comes with some example graph data in the "ImportDataExamples" subfolder. More Details on the required data format in the 'Data Format' section below

<b>Selection:</b>

Left click a node to highlight it, left click the same node again to remove the highlighting.
 
<b>Navigation:</b>

Hold down the right mouse button and move the mouse to rotate your view around the cone in the middle of your screen.

Scrolling the mouse wheel while holding down the right mouse button changes the distance of the view to the cone.

The up/down rotation of your view is limited to 60°.

The cone follows the rotation right and left, but not up or down.

"W"/"S" moves the cone to the forwards/backwards in the direction it is pointing.

"A"/"D" moves the cone to its left/right.

"Spacebar"/"Left Ctrl" moves the cone up/down.

# Data format

