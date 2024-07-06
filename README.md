## Emmetienne.SolutionReplicator
Solution Replicator is a plugin for [XrmToolbox](https://www.xrmtoolbox.com) that allows you to replicate a solution between environments. It is useful, for example, when you need to compare the customization.xml file between two environments.

## Features
 - Replicate the solution between environments
 - Filter the solution by name
 - Export the source solution and the target solution
 - Open the source and the target solution

## How to use the tool
1. Open the tool and select the source environment by clicking the "Connect to source environment" button (if not already connected to one)
2. Connect to a target environment by clicking the "Connect to target environment" button
3. Click the "Load solution from ..." button
4. Pick a solution to replicate on the target environment
5. In the "Target solution" pane, fill the "Solution name" and "Publisher" fields
6. Finally, click the "Replicate solution" button and wait for the replication process to complete
7. At the end of the process, you can see the results of the replication process in the "Source solution components" pane. The result for each item will be shown in the "Replication status" column.

## How to read the replication status column
The "Replication status" column can have five states:
 - Not yet searched -> Default state, it is not yet known if the component exists or not in the target environment
 - Found on target environment -> The component has been found on the target environment and it's replicated in the target solution
 - Not found on target environment -> The component has not been found on the target environment and thus it's not replicated in the target solution
 - Found multiple on target environment -> Multiple components have been found and each one has been added to the solution
 - Component type not yet handled by the tool -> The component type is not handled by the current version of the tool. If you find a component not handled, please open an issue 

## How this tool works
This tool works by retrieving the data of the components of the selected solution from the source environment. This data is then used to search for the same component in the target environment. If found, the component will be added to the target solution.