#region Copyright
   /*Copyright (C) 2015 Kodestruct Inc

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
   */
#endregion

using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Dynamo.Controls;
using Dynamo.Models;
using Dynamo.Wpf;
using ProtoCore.AST.AssociativeAST;
using Kodestruct.Common.CalculationLogger;
using Kodestruct.Dynamo.Common;
using Dynamo.Nodes;
using System.Xml;
using Dynamo.Graph;
using Dynamo.Graph.Nodes;


namespace Kodestruct.Concrete.ACI318.Details
{

    /// <summary>
    ///Concrete cover type  
    /// </summary>

    [NodeName("Compression lap splice length")]
    [NodeCategory("Kodestruct.Concrete.ACI318.Details")]
    [NodeDescription("Concrete cover type")]
    [IsDesignScriptCompatible]
    public class ConcreteCoverTypeSelection : UiNodeBase
    {

        public ConcreteCoverTypeSelection()
        {
            
            //OutPortData.Add(new PortData("ReportEntry", "Calculation log entries (for reporting)"));
            OutPortData.Add(new PortData("ConcreteCoverType", "Indicates the type of element and service condition for concrete cover selection"));
            RegisterAllPorts();
            SetDefaultParameters();
            //PropertyChanged += NodePropertyChanged;
        }

        private void SetDefaultParameters()
        {
            //ReportEntry="";

        }


        /// <summary>
        ///     Gets the type of this class, to be used in base class for reflection
        /// </summary>
        protected override Type GetModelType()
        {
            return GetType();
        }

        #region Properties

        #region InputProperties



	    #endregion

        #region OutputProperties

		#region ConcreteCoverTypeProperty
		
		/// <summary>
		/// ConcreteCoverType property
		/// </summary>
		/// <value>Indicates the type of element and service condition for concrete cover selection</value>
		public string _ConcreteCoverType;
		
		public string ConcreteCoverType
		{
		    get { return _ConcreteCoverType; }
		    set
		    {
		        _ConcreteCoverType = value;
		        RaisePropertyChanged("ConcreteCoverType");
		        OnNodeModified();
		    }
		}
		#endregion



        #region ReportEntryProperty

        /// <summary>
        /// log property
        /// </summary>
        /// <value>Calculation entries that can be converted into a report.</value>

        public string reportEntry;

        public string ReportEntry
        {
            get { return reportEntry; }
            set
            {
                reportEntry = value;
                RaisePropertyChanged("ReportEntry");
                OnNodeModified();
            }
        }




        #endregion

        #endregion
        #endregion

        #region Serialization

        /// <summary>
        ///Saves property values to be retained when opening the node     
        /// </summary>
        protected override void SerializeCore(XmlElement nodeElement, SaveContext context)
        {
            base.SerializeCore(nodeElement, context);
            nodeElement.SetAttribute("ConcreteCoverType", ConcreteCoverType);
        }

        /// <summary>
        ///Retrieved property values when opening the node     
        /// </summary>
        protected override void DeserializeCore(XmlElement nodeElement, SaveContext context)
        {
            base.DeserializeCore(nodeElement, context);
            var attrib = nodeElement.Attributes["ConcreteCoverType"];
            if (attrib == null)
                return;
           
            ConcreteCoverType = attrib.Value;
            //SetComponentDescription();

        }


 
        #endregion




        /// <summary>
        ///Customization of WPF view in Dynamo UI      
        /// </summary>
        public class ConcreteCoverTypeSelectionViewCustomization : UiNodeBaseViewCustomization,
            INodeViewCustomization<ConcreteCoverTypeSelection>
        {
            public void CustomizeView(ConcreteCoverTypeSelection model, NodeView nodeView)
            {
                base.CustomizeView(model, nodeView);

                ConcreteCoverTypeSelectionView control = new ConcreteCoverTypeSelectionView();
                control.DataContext = model;
                
                
                nodeView.inputGrid.Children.Add(control);
                base.CustomizeView(model, nodeView);
            }

        }
    }
}
