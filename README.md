# hololens-indoor-nav
Display live user location on minimap that follows the user. 

Build settings:
Add open scenes, choose Windows Store, SDK: Universal 10, UWP Build Type: D3D, and Check Unity C# Projects.

Additionally, go to Player Settings, look at the Windows Store settings, and under 'Other Settings' be sure that 'Virtual Reality Supported' is checked, with the Windows Holographic SDK selected. Also under Publishing settings, be sure that Microphone and Spatial Perception are checked.

Running:
(If you have an image of your floorplan, replace it in the Map Shader before building)

1. Air tap on the two cubes and place them  within your environment (preferably at the same height).

2. Next, face the map, and air tap it once to place the first control point, then a second time to place the other one. Place them on the map where they correspond with the physical locations of the other control points.

3. Walk around.

Voice commands:
Toggle Mapping :  turn on spatial mapping.
Toggle Follow : map will follow your gaze but stay at a height 0.3m below your head.
Toggle Cylinders: turn on debug cylinders that point between control points, to your head postion projected onto the floor (this was for debugging math on translating the user position).
