[![Build and Release](https://github.com/emmetienne/Emmetienne.SolutionReplicator/actions/workflows/build-and-release.yml/badge.svg?branch=main)](https://github.com/emmetienne/Emmetienne.SolutionReplicator/actions/workflows/build-and-release.yml)

## Emmetienne.SolutionReplicator
Solution Replicator is a plugin for [XrmToolbox](https://www.xrmtoolbox.com) that allows you to replicate a solution between environments. It is useful, for example, when you need to compare the customization.xml file between two environments.

## Changelog
1.2024.8.1 - Fixed some bugs and refactored some code, renamed the “Replication status” column in the solution components pane to “Component search result”, added “Replicated” and “Error message” columns to the solution components pane to show if the components have been successfully replicated
1.2024.7.2 - Added a checkbox to show managed solutions in the solution pane (they're hidden by default), added handling for components of type Custom Control (66) and Canvas App (300), implemented solution name validation
1.2024.7.1 - Minor refactoring
1.2024.6.1 - First nuget release of the tool

## Features
 - Replicate the solution between environments
 - Filter the solution by name          
 - Filter out managed solutions (the default behaviour is to not show managed solutions) 
 - Export the source solution and the target solution
 - Open the source and the target solution

## How to use the tool
1. Open the tool and select the source environment by clicking the "Connect to source environment" button (if not already connected to one)
2. Connect to a target environment by clicking the "Connect to target environment" button
3. Click the "Load solution from ..." buttons
4. Pick a solution to replicate on the target environment
5. In the "Target solution" pane, fill the "Solution name" and "Publisher" fields
6. Finally, click the "Replicate solution" button and wait for the replication process to complete
7. At the end of the process, you can see the following for each component:
	- In the “Component search status” column of the solution components pane, you can see if the components have been found in the target environment (please refer to the “How to read the “Component search status” column” paragraph for more info)
	- In the "Replicated" column of the solution components pane you can see if the component has been successfully replicated, components that have been found in the target environment but not replicated will not be checked and will be highlighted with a black background color
	- In the "Error message" column of the solution components pane you can see the error message if the component has not been replicated
	
## How to read the "Component search status" column
The "Component search status" column can have five states:
 - Not yet searched -> Default state, it is not yet known if the component exists or not in the target environment
 - Found on target environment -> The component has been found on the target environment and it's replicated in the target solution
 - Not found on target environment -> The component has not been found on the target environment and thus it's not replicated in the target solution
 - Found multiple on target environment -> Multiple components have been found and each one has been added to the solution
 - Component type not yet handled by the tool -> The component type is not handled by the current version of the tool. If you find a component not handled, please open an issue 
 - Error -> An error has occoured and therefore the component will not be replicated, the exception will be logged. If you find an error, please open an issue 

## How this tool works
This tool works by retrieving the data of the components of the selected solution from the source environment. This data is then used to search for the same component in the target environment. If found, the component will be added to the target solution.