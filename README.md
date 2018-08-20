# Graph3d
3D Graph Visualization Tool created with Unity3d 5.5.4

The "Assets" folder should contain everything you need to open and rund the project in Unity. The C# source code hides in Assets/scripts.

# Installation and Usage

<b>On Windows:</b>
Download and unzip the G3DBuild.zip. Its a standalone build, so just start the G3D.exe and enjoy!

<b>Loading graph data:</b>

To load a Graph, use the "Open"-Button and select a folder containing "Nodes.csv" and "Edges.csv".
The Build comes with some example graph data in the "ImportDataExamples" subfolder. More Details on the reqired data format in the 'Data Format' section below

<b>Selection:</b>

Left click a node to highlight it, left click the same node again to remove the highlighting.
 
<b>Navigation:</b>

Hold down the right mouse button and move the mouse to rotate your view around cone in the middle of your screen.

Scrolling the mousewheel while holding down the right mouse button changes the distance of the view to the cone.

The up/down rotation of your view is limited to 60°.

The cone follows the rotation right and left, but not up or down.

"W"/"S" moves the cone to the forwards/backwards in the direction it is pointing.

"A"/"D" moves the cone to its left/right.

"Spacebar"/"Left Ctrl" moves the cone up/down.

# Data format
