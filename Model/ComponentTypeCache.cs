using Emmetienne.SolutionReplicator.Model.Entities;
using Emmetienne.SolutionReplicator.Repository;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Emmetienne.SolutionReplicator.Model
{
    public class ComponentTypeCache : Singleton<ComponentTypeCache>
    {
        private readonly Dictionary<int, ComponentType> FixedOptionSetComponentTypeNameDictionary = new Dictionary<int, ComponentType>()
       {
            {1,  new ComponentType { ComponentTypeName="Entity"                               , ComponentEntityLogicalName = "entity", ComponentPrimaryFieldLogicalName ="name"             }},
            {2,  new ComponentType { ComponentTypeName="Attribute"                            , ComponentEntityLogicalName = "attribute", ComponentPrimaryFieldLogicalName ="name"                }},
            {3,  new ComponentType { ComponentTypeName="Relationship"                         , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                   }},
            // dunno
            {4,  new ComponentType { ComponentTypeName="Attribute Picklist Value"             , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                               }},
            // dunno
            {5,  new ComponentType { ComponentTypeName="Attribute Lookup Value"               , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                             }},
            // dunno
            {6,  new ComponentType { ComponentTypeName="View Attribute"                       , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                     }},
            // dunno
            {7,  new ComponentType { ComponentTypeName="Localized Label"                      , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                      }},
            // dunno
            {8,  new ComponentType { ComponentTypeName="Relationship Extra Condition"         , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                                   }},
            {9,  new ComponentType { ComponentTypeName="Option Set"                           , ComponentEntityLogicalName = "optionset", ComponentPrimaryFieldLogicalName ="name"                 }},
            {10, new ComponentType { ComponentTypeName="Entity Relationship"                  , ComponentEntityLogicalName = "entityrelationship", ComponentPrimaryFieldLogicalName ="schemaname"                          }},
            // dunno
            {11, new ComponentType { ComponentTypeName="Entity Relationship Role"             , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                               }},
            // dunno
            {12, new ComponentType { ComponentTypeName="Entity Relationship Relationships"    , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                                        }},

            {13, new ComponentType { ComponentTypeName="Managed Property"                     , ComponentEntityLogicalName = "managedproperty", ComponentPrimaryFieldLogicalName ="name"                       }},
            {14, new ComponentType { ComponentTypeName="Entity Key"                           , ComponentEntityLogicalName = "entitykey", ComponentPrimaryFieldLogicalName ="name"                 }},
            // find out if 16 and 17 needs a bespoke strategy
            {16, new ComponentType { ComponentTypeName="Privilege"                            , ComponentEntityLogicalName = "privilege", ComponentPrimaryFieldLogicalName ="name"                }},
            {17, new ComponentType { ComponentTypeName="PrivilegeObjectTypeCode"              , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                              }},
            // dunno
            {18, new ComponentType { ComponentTypeName="Index"                                , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""            }},
            // find out if 20 and 21 needs a bespoke strategy
            {20, new ComponentType { ComponentTypeName="Role"                                 , ComponentEntityLogicalName = "role", ComponentPrimaryFieldLogicalName ="name", NullFieldsForComparisonList =  new List<string>{"parentroleid" } }},
            {21, new ComponentType { ComponentTypeName="Role Privilege"                       , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                     }},
            // find out if 22 and 23 needs a bespoke strategy
            {22, new ComponentType { ComponentTypeName="Display String"                       , ComponentEntityLogicalName = "displaystring", ComponentPrimaryFieldLogicalName ="displaystringkey"                     }},
            {23, new ComponentType { ComponentTypeName="Display String Map"                   , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                         }},
            // dunno
            {24, new ComponentType { ComponentTypeName="Form"                                 , ComponentEntityLogicalName = "systemform", ComponentPrimaryFieldLogicalName ="name"           }},
            {25, new ComponentType { ComponentTypeName="Organization"                         , ComponentEntityLogicalName = "organization", ComponentPrimaryFieldLogicalName ="name"                   }},
            {26, new ComponentType { ComponentTypeName="Saved Query"                          , ComponentEntityLogicalName = "savedquery", ComponentPrimaryFieldLogicalName ="name"                  }},
            {29, new ComponentType { ComponentTypeName="Workflow"                             , ComponentEntityLogicalName = "workflow", ComponentPrimaryFieldLogicalName ="name"               }},
            // find out if 31, 32, 33 and 34 needs a bespoke strategy
            {31, new ComponentType { ComponentTypeName="Report"                               , ComponentEntityLogicalName = "report", ComponentPrimaryFieldLogicalName ="name"             }},
            {32, new ComponentType { ComponentTypeName="Report Entity"                        , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                    }}, //boh
            {33, new ComponentType { ComponentTypeName="Report Category"                      , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                      }},
            {34, new ComponentType { ComponentTypeName="Report Visibility"                    , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                        }},
            {35, new ComponentType { ComponentTypeName="Attachment"                           , ComponentEntityLogicalName = "attachment", ComponentPrimaryFieldLogicalName ="filename"                 }},
            {36, new ComponentType { ComponentTypeName="Email Template"                       , ComponentEntityLogicalName = "template", ComponentPrimaryFieldLogicalName ="title"                     }},
            {37, new ComponentType { ComponentTypeName="Contract Template"                    , ComponentEntityLogicalName = "contracttemplate", ComponentPrimaryFieldLogicalName ="name"                        }},
            {38, new ComponentType { ComponentTypeName="KB Article Template"                  , ComponentEntityLogicalName = "kbarticletemplate", ComponentPrimaryFieldLogicalName ="title"                          }},
            {39, new ComponentType { ComponentTypeName="Mail Merge Template"                  , ComponentEntityLogicalName = "mailmergetemplate", ComponentPrimaryFieldLogicalName ="name"                          }},
            // find out if 44 and 45enti needs a bespoke strategy
            {44, new ComponentType { ComponentTypeName="Duplicate Rule"                       , ComponentEntityLogicalName = "duplicaterule", ComponentPrimaryFieldLogicalName ="name"                     }},
            {45, new ComponentType { ComponentTypeName="Duplicate Rule Condition"             , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                               }},
            // 46 and 47 doesn't need a bespoke strategy or anything else, they're added to the solution with the relationship
            {46, new ComponentType { ComponentTypeName="Entity Map"                           , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                 }},
            {47, new ComponentType { ComponentTypeName="Attribute Map"                        , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                    }},
            // ribbon * are moved trough solution?
            {48, new ComponentType { ComponentTypeName="Ribbon Command"                       , ComponentEntityLogicalName = "ribboncommand", ComponentPrimaryFieldLogicalName ="command"                     }},
            // dunno
            {49, new ComponentType { ComponentTypeName="Ribbon Context Group"                 , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                           }},
            // dunno
            {50, new ComponentType { ComponentTypeName="Ribbon Customization"                 , ComponentEntityLogicalName = "ribboncustomization", ComponentPrimaryFieldLogicalName ="entity"                           }},
            // dunno
            {52, new ComponentType { ComponentTypeName="Ribbon Rule"                          , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                  }},
            // dunno
            {53, new ComponentType { ComponentTypeName="Ribbon Tab To Command Map"            , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                                }},
            // dunno
            {55, new ComponentType { ComponentTypeName="Ribbon Diff"                          , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                  }},
            // mix primaryentitytypecode and name
            {59, new ComponentType { ComponentTypeName="Saved Query Visualization"            , ComponentEntityLogicalName = "savedqueryvisualization", ComponentPrimaryFieldLogicalName ="name"                                }},
            {60, new ComponentType { ComponentTypeName="System Form"                          , ComponentEntityLogicalName = "systemform", ComponentPrimaryFieldLogicalName ="name"   ,ComponentPrimaryKeyLogicalName = "formid"   , AdditionalFieldsForComparisonList = new List<AdditionalComponentFieldForComparison>{ AdditionalComponentFieldForComparison.Create("objecttypecode",typeof(string)), AdditionalComponentFieldForComparison.Create("type", typeof(OptionSetValue)) }          }},
            {61, new ComponentType { ComponentTypeName="Web Resource"                         , ComponentEntityLogicalName = "webresource", ComponentPrimaryFieldLogicalName ="name"                   }},
            {62, new ComponentType { ComponentTypeName="Site Map"                             , ComponentEntityLogicalName = "sitemap", ComponentPrimaryFieldLogicalName ="sitemapname"               }},
            {63, new ComponentType { ComponentTypeName="Connection Role"                      , ComponentEntityLogicalName = "connectionrole", ComponentPrimaryFieldLogicalName ="name"                      }},
            // cannot retrieve with retrieve multiple request
            {64, new ComponentType { ComponentTypeName="Complex Control"                      , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                      }},
            {65, new ComponentType { ComponentTypeName="Hierarchy Rule"                       , ComponentEntityLogicalName = "hierarchyrule", ComponentPrimaryFieldLogicalName ="name"                     }},
            {66, new ComponentType { ComponentTypeName="Custom Control"                       , ComponentEntityLogicalName = "customcontrol", ComponentPrimaryFieldLogicalName ="name"                     }},
            {68, new ComponentType { ComponentTypeName="Custom Control Default Config"        , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                                    }},
            {70, new ComponentType { ComponentTypeName="Field Security Profile"               , ComponentEntityLogicalName = "fieldsecurityprofile", ComponentPrimaryFieldLogicalName ="name"                             }},
            {71, new ComponentType { ComponentTypeName="Field Permission"                     , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                       }},
            {80, new ComponentType { ComponentTypeName="Model Driven App"                     , ComponentEntityLogicalName = "appmodule", ComponentPrimaryFieldLogicalName ="name"                  }},
            {90, new ComponentType { ComponentTypeName="Plugin Type"                          , ComponentEntityLogicalName = "plugintype", ComponentPrimaryFieldLogicalName ="name"                  }},
            {91, new ComponentType { ComponentTypeName="Plugin Assembly"                      , ComponentEntityLogicalName = "pluginassembly", ComponentPrimaryFieldLogicalName ="name"                      }},
            {92, new ComponentType { ComponentTypeName="SDK Message Processing Step"          , ComponentEntityLogicalName = "sdkmessageprocessingstep", ComponentPrimaryFieldLogicalName ="name"                                  }},
            {93, new ComponentType { ComponentTypeName="SDK Message Processing Step Image"    , ComponentEntityLogicalName = "sdkmessageprocessingstepimage", ComponentPrimaryFieldLogicalName ="name"                                        }},
            {95, new ComponentType { ComponentTypeName="Service Endpoint"                     , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                       }},
            {150,new ComponentType { ComponentTypeName="Routing Rule"                         , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                   }},
            {151,new ComponentType { ComponentTypeName="Routing Rule Item"                    , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                        }},
            {152,new ComponentType { ComponentTypeName="SLA"                                  , ComponentEntityLogicalName = "sla", ComponentPrimaryFieldLogicalName ="slaidunique"   , ComponentPrimaryFieldType = typeof(Guid)       }},
            {153,new ComponentType { ComponentTypeName="SLA Item"                             , ComponentEntityLogicalName = "slaitem", ComponentPrimaryFieldLogicalName ="slaitemidunique" , ComponentPrimaryFieldType = typeof(Guid)                }},
            {154,new ComponentType { ComponentTypeName="Convert Rule"                         , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                   }},
            {155,new ComponentType { ComponentTypeName="Convert Rule Item"                    , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                        }},
            {161,new ComponentType { ComponentTypeName="Mobile Offline Profile"               , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                             }},
            {162,new ComponentType { ComponentTypeName="Mobile Offline Profile Item"          , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                                  }},
            {165,new ComponentType { ComponentTypeName="Similarity Rule"                      , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                      }},
            {166,new ComponentType { ComponentTypeName="Data Source Mapping"                  , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                          }},
            {201,new ComponentType { ComponentTypeName="SDKMessage"                           , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                 }},
            {202,new ComponentType { ComponentTypeName="SDKMessageFilter"                     , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                       }},
            {203,new ComponentType { ComponentTypeName="SdkMessagePair"                       , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                     }},
            {204,new ComponentType { ComponentTypeName="SdkMessageRequest"                    , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                        }},
            {205,new ComponentType { ComponentTypeName="SdkMessageRequestField"               , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                             }},
            {206,new ComponentType { ComponentTypeName="SdkMessageResponse"                   , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                         }},
            {207,new ComponentType { ComponentTypeName="SdkMessageResponseField"              , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                              }},
            {208,new ComponentType { ComponentTypeName="Import Map"                           , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                 }},
            {210,new ComponentType { ComponentTypeName="WebWizard"                            , ComponentEntityLogicalName = "", ComponentPrimaryFieldLogicalName =""                    } }
    };

        private Dictionary<int, ComponentType> DynamicsComponentTypeDictionary = new Dictionary<int, ComponentType>();

        private readonly Dictionary<string, ComponentType> SpecialRulesForSolutionComponentDefinitionDictionary = new Dictionary<string, ComponentType>(StringComparer.OrdinalIgnoreCase)
       {
            {"customapi",new ComponentType { ComponentTypeName="Custom API"                            , ComponentEntityLogicalName = "customapi", ComponentPrimaryFieldLogicalName ="uniquename"                    } },
            {"customapirequestparameter",new ComponentType { ComponentTypeName="Custom API Request Parameter"                            , ComponentEntityLogicalName = "customapirequestparameter", ComponentPrimaryFieldLogicalName ="name"/*,  AdditionalFieldsForComparisonList = new List<AdditionalComponentFieldForComparison>{ AdditionalComponentFieldForComparison.Create("customapiid",typeof(EntityReference)) }*/                        } },
            {"customapiresponseproperty",new ComponentType { ComponentTypeName="Custom API Response Parameter"                           , ComponentEntityLogicalName = "customapiresponseproperty", ComponentPrimaryFieldLogicalName ="name"/*, AdditionalFieldsForComparisonList = new List<AdditionalComponentFieldForComparison>{ AdditionalComponentFieldForComparison.Create("customapiid",typeof(EntityReference))  }*/                   } },
            {"settingdefinition",new ComponentType { ComponentTypeName="Setting Definition"                           , ComponentEntityLogicalName = "settingdefinition", ComponentPrimaryFieldLogicalName ="uniquename" , DoNotAddToSolution = false                   } },
            {"organizationsetting",new ComponentType { ComponentTypeName="Organization Settings"                           , ComponentEntityLogicalName = "organizationsetting", ComponentPrimaryFieldLogicalName ="uniquename", DoNotAddToSolution = false                    } },
            {"appelement",new ComponentType { ComponentTypeName="App Element"                           , ComponentEntityLogicalName = "appelement", ComponentPrimaryFieldLogicalName ="uniquename", DoNotAddToSolution = false                    } },
            {"appsetting",new ComponentType { ComponentTypeName="App Setting"                           , ComponentEntityLogicalName = "appsetting", ComponentPrimaryFieldLogicalName ="componentidunique", DoNotAddToSolution = false, ComponentPrimaryFieldType=typeof(Guid),  AdditionalFieldsForComparisonList = new List<AdditionalComponentFieldForComparison>{ AdditionalComponentFieldForComparison.Create("parentappmoduleid",typeof(EntityReference)) }                    } },
            {"connectionreference",new ComponentType { ComponentTypeName="Connection Reference"                           , ComponentEntityLogicalName = "connectionreference", ComponentPrimaryFieldLogicalName ="connectionreferencelogicalname", DoNotAddToSolution = false                    } },
            {"msdyn_slakpi",new ComponentType { ComponentTypeName="SLA KPI"                           , ComponentEntityLogicalName = "msdyn_slakpi", ComponentPrimaryFieldLogicalName ="msdyn_name", DoNotAddToSolution = false                    } },
            {"msdyn_applicationtabtemplate",new ComponentType { ComponentTypeName="Application Tab Template"                           , ComponentEntityLogicalName = "msdyn_applicationtabtemplate", ComponentPrimaryFieldLogicalName ="msdyn_uniquename", DoNotAddToSolution = false                    } },
            {"msdyn_sessiontemplate",new ComponentType { ComponentTypeName="Session template"                           , ComponentEntityLogicalName = "msdyn_sessiontemplate", ComponentPrimaryFieldLogicalName ="msdyn_uniquename", DoNotAddToSolution = false                    } },
            {"msdyn_templateparameter",new ComponentType { ComponentTypeName="Template parameter"                           , ComponentEntityLogicalName = "msdyn_templateparameter", ComponentPrimaryFieldLogicalName ="msdyn_uniquename", DoNotAddToSolution = false                    } },
            {"msdyn_sessiontemplate_applicationtab",new ComponentType { ComponentTypeName="Template parameter"                           , ComponentEntityLogicalName = "msdyn_sessiontemplate_applicationtab", ComponentPrimaryFieldLogicalName ="componentidunique", DoNotAddToSolution = false                    }
            },
            {"canvasapp",new ComponentType { ComponentTypeName="Canvas App"                           , ComponentEntityLogicalName = "canvasapp", ComponentPrimaryFieldLogicalName ="name", DoNotAddToSolution = false                    }
            },
            {"environmentvariabledefinition",new ComponentType { ComponentTypeName="Environment Variable Definition"                           , ComponentEntityLogicalName = "environmentvariabledefinition", ComponentPrimaryFieldLogicalName ="displayname", DoNotAddToSolution = false                    }
            },
            {"environmentvariablevalue",new ComponentType { ComponentTypeName="Environment Variable Value"                           , ComponentEntityLogicalName = "environmentvariablevalue", ComponentPrimaryFieldLogicalName ="schemaname", DoNotAddToSolution = false  }
            }
       };

        public ComponentType GetComponentTypeFromComponentTypeCode(int componentTypeCode)
        {
            if (FixedOptionSetComponentTypeNameDictionary.ContainsKey(componentTypeCode))
                return FixedOptionSetComponentTypeNameDictionary[componentTypeCode];

            if (DynamicsComponentTypeDictionary.ContainsKey(componentTypeCode))
                return DynamicsComponentTypeDictionary[componentTypeCode];

            return null;
        }

        public bool ContainsKey(int componentType)
        {
            return FixedOptionSetComponentTypeNameDictionary.ContainsKey(componentType) || DynamicsComponentTypeDictionary.ContainsKey(componentType);
        }

        public string GetComponentTypeNameFromComponentType(int componentType)
        {
            if (FixedOptionSetComponentTypeNameDictionary.ContainsKey(componentType))
                return FixedOptionSetComponentTypeNameDictionary[componentType].ComponentTypeName;

            if (DynamicsComponentTypeDictionary.ContainsKey(componentType))
                return DynamicsComponentTypeDictionary[componentType].ComponentTypeName;

            return "N/A";
        }


        public void InvalidateDynamicCache()
        {
            DynamicsComponentTypeDictionary.Clear();
        }


        public ComponentType ToComponentType(Entity entity, bool source = true)
        {
            var tmpComponentType = new ComponentType();

            tmpComponentType.ComponentEntityLogicalName = entity.GetAttributeValue<string>(solutioncomponentdefinition.primaryentityname);

            if (source && SpecialRulesForSolutionComponentDefinitionDictionary.ContainsKey(tmpComponentType.ComponentEntityLogicalName))
                return SpecialRulesForSolutionComponentDefinitionDictionary[tmpComponentType.ComponentEntityLogicalName];

            tmpComponentType.ComponentTypeName = entity.GetAttributeValue<string>(solutioncomponentdefinition.name);
            tmpComponentType.DoNotAddToSolution = false;
            tmpComponentType.ComponentPrimaryFieldLogicalName = "name";

            return tmpComponentType;
        }

        public void HandleComponentCache(IOrganizationService sourceService, IOrganizationService targetService)
        {
            if (sourceService == null)
                return;

            var sourceSolutionComponentDefinitionRepository = new SolutionComponentsDefinitionsRepository(sourceService);
            var sourceSolutionComponentDefinitionList = sourceSolutionComponentDefinitionRepository.GetSolutionComponentDefinitions();

            List<Entity> targetSolutionComponentDefinition = null;

            foreach (var singleSolutionComponentDefinition in sourceSolutionComponentDefinitionList)
            {
                var tmpComponentType = ToComponentType(singleSolutionComponentDefinition, true);
                var solutionComponentType = singleSolutionComponentDefinition.GetAttributeValue<int>(solutioncomponentdefinition.solutioncomponenttype);

                DynamicsComponentTypeDictionary[solutionComponentType] = tmpComponentType;
            }

            if (targetService == null)
                return;

            var targetSolutionComponentDefinitionRepository = new SolutionComponentsDefinitionsRepository(targetService);
            targetSolutionComponentDefinition = targetSolutionComponentDefinitionRepository.GetSolutionComponentDefinitions();

            foreach (var entry in DynamicsComponentTypeDictionary)
            {
                var foundTargetSolutionComponentDefinition = targetSolutionComponentDefinition.FirstOrDefault(x => x.GetAttributeValue<string>(solutioncomponentdefinition.primaryentityname) == DynamicsComponentTypeDictionary[entry.Key].ComponentEntityLogicalName);

                if (foundTargetSolutionComponentDefinition == null)
                    continue;

                DynamicsComponentTypeDictionary[entry.Key].TargetComponentTypeCode = foundTargetSolutionComponentDefinition.GetAttributeValue<int>(solutioncomponentdefinition.solutioncomponenttype);
            }
        }
    }
}