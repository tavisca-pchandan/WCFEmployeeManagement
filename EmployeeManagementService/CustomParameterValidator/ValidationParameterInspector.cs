using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text.RegularExpressions;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;



namespace CustomParameterValidator
{
    public class ValidationParameterInspector : IParameterInspector
        {
        


            public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
            {
            }

            public object BeforeCall(string operationName, object[] inputs)
            {
               
                if (operationName == "CreateEmployee")
                {
                    //Check name...
                   
                    Regex r = new Regex("^[a-zA-Z ]+$", RegexOptions.Compiled);
                    if (r.IsMatch(inputs[0].ToString()))
                        return true;
                    else
                    {
                        throw new System.ServiceModel.FaultException("Invalid Parameter : Name should contains alphanumeric characters only");
                    }
                }

                else if (operationName == "AddRemarks")
                {
                    //Check GUID and Remark...
                    Regex r = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
                    if (r.IsMatch(inputs[0].ToString()))
                    {
                        r = new Regex("^[a-zA-Z ]+$", RegexOptions.Compiled);
                        if (r.IsMatch(inputs[1].ToString()))
                        {
                            return true;
                        }
                        else
                        {
                            throw new System.ServiceModel.FaultException("Invalid Remark");
                        }
                    }
                    else
                    {
                        throw new System.ServiceModel.FaultException("Invalid GUID");
                    }

                   
                }

                else if (operationName == "SearchById")
                {
                    Regex r = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
                    if (r.IsMatch(inputs[0].ToString()))
                    {
                        return true;
                    }
                    else
                    {
                        throw new System.ServiceModel.FaultException("Invalid Guid");
                    }
                }

                else if (operationName == "SearchByName")
                {
                    Regex r = new Regex("^[a-zA-Z ]+$", RegexOptions.Compiled);
                    if (r.IsMatch(inputs[0].ToString()))
                    {
                        return true;
                    }
                    else
                    {
                        throw new System.ServiceModel.FaultException("Invalid Name");
                    }
                }
                return null;
            }
        }

}
