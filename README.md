# Graph3d
is a force driven 3D graph visualization tool that automatically clusters strongly connected nodes and separates weakly connected areas, employing the Barnes-Hut algorithm for manybody-simulations to keep CPU-Load in check ( O(n\*log(n)) instead of O(2^n) ). - created with Unity3d 5.5.4.

![rotate and force demo gif](https://github.com/JanMMeyer/G3DDemos/blob/master/g3ddemorotatesmall.gif)
![select demo gif](https://github.com/JanMMeyer/G3DDemos/blob/master/g3ddemoselectsmall.gif)


<b>The project is currently in alpha stage.</b>

Graph3d is also an *experiment in solid programming i wrote in my free time over the course of some weeks*, that might suffer from over engineered solutions in some place, which served more as an exercise ground than being well-measured solutions in terms of code complexity. Anyway, the code structure was laid out to achieve among other things the folloing goals:
 * Encapsulation of the frontend, in a manner that it can be easily exchanged for another implementation, that does not rely on Unity3d.
 * Extensibility of the backend, so that new file adapters can be added with ease.
 * Flexibility of the business layer, so that extensions of the core domain are simple to execute and don't lead to (to much) adaptation pressure outside of the domain. 

The "Assets" folder contains only the Graph3d-Assets. Graph3d uses the [crosstales file browser plugin](https://goo.gl/GCmzrU) which needs to be installed separately via the asset-store to build the project in Unity3d. The C# source code hides in Assets/scripts.

# Installation and Usage

<b>On Windows:</b>
Download and unzip the [latest release](https://github.com/JanMMeyer/Graph3d/releases/latest). It's a standalone build, so just start the G3D.exe and enjoy!

<b>Loading graph data:</b>

To load a Graph, use the "Open"-Button and select a folder containing "Nodes.csv" and "Edges.csv".
The Build comes with some example graph data in the "ImportDataExamples" subfolder. More Details on the required data format in the [Data Format](#data-format) section below.

<b>Force Adjustment</b>

The slider section on the left allows real-time adjustment of the forces at work. "Node Repulsion" forces the *all* nodes apart, "Edge Attraction" pulls *connected* Nodes together, and "Centering Force" pulls all nodes to the centre.

<b>Selection:</b>

Left click a node to highlight it, left click the same node again to remove the highlighting.
 
<b>Navigation:</b>

Hold down the right mouse button and move the mouse to rotate your view around the cone in the middle of your screen.

Scrolling the mouse wheel while holding down the right mouse button changes the distance of the view to the cone.

The up/down rotation of your view is limited to 60° measured relative to the horizontal plane.

The cone follows the rotation right and left, but not up or down.

"W"/"S" moves the cone to the forwards/backwards in the direction it is pointing.

"A"/"D" moves the cone to its left/right.

"Spacebar"/"Left Ctrl" moves the cone up/down.

# Data format

The graph data needs to be provided in two separate csv-files "Nodes.csv" and "Edges.csv" with ";" (semicolon) as delimiter. 

Each file needs a header, containing at least an "id" column for the "Nodes.csv" and "id" , "source" and "target" columns for "Edges.csv. 

The "label" column for "Nodes.csv" is optional and sets the visible *names* of the nodes. In "Edges.csv" a "type" column is optional and supports the values "u" for undirected and "d" for directed edges. A "label" for Edges will be implemented soon.

The "id" fields in each file must be file-wide unique but are parsed as strings, i.e. any alphanumerical expression is ok.

The "source" and "target" fields in "Edges.csv" need to correspond to "id"s in "Nodes.cvs", and determine which nodes are connected by that edge.

