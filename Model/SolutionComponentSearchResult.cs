using System.Collections.Generic;
using System.Drawing;

namespace Emmetienne.SolutionReplicator.Model
{
    public class ComponentSearchResult
    {
        public string Message { get; set; }
        public Color ForeGroundColor { get; set; }
        public SolutionComponentSearchResult SolutionComponentSearchResult { get; set; }
        
               public static readonly Dictionary<SolutionComponentSearchResult, ComponentSearchResult> searchResultOptionDictionary
                                    = new Dictionary<SolutionComponentSearchResult, ComponentSearchResult>()
                                    {
                                            { SolutionComponentSearchResult.notYetSearched, new ComponentSearchResult { Message = "Not yet searched", ForeGroundColor = Color.Black  } },
                                            { SolutionComponentSearchResult.foundOnTargetEnvironment, new ComponentSearchResult { Message = "Found on target environment", ForeGroundColor = Color.Green } },
                                            { SolutionComponentSearchResult.notFoundOnTargetEnvironment, new ComponentSearchResult { Message = "Not found on target environment", ForeGroundColor = Color.Red } },
                                            { SolutionComponentSearchResult.foundMultipleOnTargetEnvironment, new ComponentSearchResult { Message = "Found multiple on target environment", ForeGroundColor = Color.Orange } },
                                            { SolutionComponentSearchResult.notYetHandled, new ComponentSearchResult { Message = "Component type not yet handled by the tool", ForeGroundColor = Color.Purple } },
                                            { SolutionComponentSearchResult.error, new ComponentSearchResult { Message = "Error, see log for more info", ForeGroundColor = Color.DarkRed } }
                                    };
    }

    public enum SolutionComponentSearchResult
    {
        notYetSearched,
        foundOnTargetEnvironment,
        notFoundOnTargetEnvironment,
        foundMultipleOnTargetEnvironment,
        notYetHandled,
        error
    }
}
