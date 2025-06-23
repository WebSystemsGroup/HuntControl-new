using HuntControl.Domain.Concrete;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace WebAIS.Models
{
    public class KcrModel
    {
        public class digitalRegulations
        {
            public kcrResponseType drData;
            public spr_services_sub_tariff[] tariff;
            public spr_services serviceData;
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        [XmlRootAttribute("KCRRequest", Namespace = "urn://rostelekom.ru/KCR/1.0.4", IsNullable = false)]
        public partial class kcrRequestType
        {

            private string kcrIdField;

            private bool isActivatedField;

            private bool isActivatedFieldSpecified;

            /// <remarks/>
            public string kcrId
            {
                get => kcrIdField;
                set => kcrIdField = value;
            }

            /// <remarks/>
            public bool isActivated
            {
                get => isActivatedField;
                set => isActivatedField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isActivatedSpecified
            {
                get => isActivatedFieldSpecified;
                set => isActivatedFieldSpecified = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class proactivitySFType
        {

            private dictionarySFType[] additionalInformationIdsField;

            private dictionarySFType[] infSystemSourceField;

            private dictionarySFType[] infSystemTargetField;

            private dictionarySFType proactivitySystemField;

            private dictionarySFType[] proactivityTriggersField;

            /// <remarks/>
            [XmlElementAttribute("additionalInformationIds")]
            public dictionarySFType[] additionalInformationIds
            {
                get => additionalInformationIdsField;
                set => additionalInformationIdsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("infSystemSource")]
            public dictionarySFType[] infSystemSource
            {
                get => infSystemSourceField;
                set => infSystemSourceField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("infSystemTarget")]
            public dictionarySFType[] infSystemTarget
            {
                get => infSystemTargetField;
                set => infSystemTargetField = value;
            }

            /// <remarks/>
            public dictionarySFType proactivitySystem
            {
                get => proactivitySystemField;
                set => proactivitySystemField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("proactivityTriggers")]
            public dictionarySFType[] proactivityTriggers
            {
                get => proactivityTriggersField;
                set => proactivityTriggersField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class dictionarySFType
        {

            private string idField;

            private string dictionaryCodeField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string dictionaryCode
            {
                get => dictionaryCodeField;
                set => dictionaryCodeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class proactiveSFType
        {

            private proactivitySFType proactivityField;

            private dictionarySFType[] reasonsStartProactiveIdsField;

            /// <remarks/>
            public proactivitySFType proactivity
            {
                get => proactivityField;
                set => proactivityField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("reasonsStartProactiveIds")]
            public dictionarySFType[] reasonsStartProactiveIds
            {
                get => reasonsStartProactiveIdsField;
                set => reasonsStartProactiveIdsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class lanesType
        {

            private string idField;

            private string laneNameField;

            private fullDictionaryType laneChannelField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string laneName
            {
                get => laneNameField;
                set => laneNameField = value;
            }

            /// <remarks/>
            public fullDictionaryType laneChannel
            {
                get => laneChannelField;
                set => laneChannelField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class fullDictionaryType
        {

            private string idField;

            private string nameField;

            private string dictionaryCodeField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string name
            {
                get => nameField;
                set => nameField = value;
            }

            /// <remarks/>
            public string dictionaryCode
            {
                get => dictionaryCodeField;
                set => dictionaryCodeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class hookupType
        {

            private string idField;

            private string typeField;

            private string laneIdField;

            private string gatewayNameField;

            private string gatewayTypeField;

            private string gatewayQuestionField;

            private string[] gatewayAnswersField;

            private string[] exitsField;

            private string[] entersField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string type
            {
                get => typeField;
                set => typeField = value;
            }

            /// <remarks/>
            public string laneId
            {
                get => laneIdField;
                set => laneIdField = value;
            }

            /// <remarks/>
            public string gatewayName
            {
                get => gatewayNameField;
                set => gatewayNameField = value;
            }

            /// <remarks/>
            public string gatewayType
            {
                get => gatewayTypeField;
                set => gatewayTypeField = value;
            }

            /// <remarks/>
            public string gatewayQuestion
            {
                get => gatewayQuestionField;
                set => gatewayQuestionField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("gatewayAnswers")]
            public string[] gatewayAnswers
            {
                get => gatewayAnswersField;
                set => gatewayAnswersField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("exits")]
            public string[] exits
            {
                get => exitsField;
                set => exitsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("enters")]
            public string[] enters
            {
                get => entersField;
                set => entersField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class administrativeActionsSFType
        {

            private string idField;

            private string idProceduresField;

            private string laneIdField;

            private string[] exitsField;

            private string[] entersField;

            private dictionarySFType nameField;

            private dictionarySFType innerStatusField;

            private dictionarySFType epguStatusField;

            private dictionarySFType performedByField;

            private dictionarySFType timeFrameUnitField;

            private dictionarySFType timeMvzUnitField;

            private dictionarySFType[] reasonsAdditionalInformationField;

            private dictionarySFType[] authoritiesField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string idProcedures
            {
                get => idProceduresField;
                set => idProceduresField = value;
            }

            /// <remarks/>
            public string laneId
            {
                get => laneIdField;
                set => laneIdField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("exits")]
            public string[] exits
            {
                get => exitsField;
                set => exitsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("enters")]
            public string[] enters
            {
                get => entersField;
                set => entersField = value;
            }

            /// <remarks/>
            public dictionarySFType name
            {
                get => nameField;
                set => nameField = value;
            }

            /// <remarks/>
            public dictionarySFType innerStatus
            {
                get => innerStatusField;
                set => innerStatusField = value;
            }

            /// <remarks/>
            public dictionarySFType epguStatus
            {
                get => epguStatusField;
                set => epguStatusField = value;
            }

            /// <remarks/>
            public dictionarySFType performedBy
            {
                get => performedByField;
                set => performedByField = value;
            }

            /// <remarks/>
            public dictionarySFType timeFrameUnit
            {
                get => timeFrameUnitField;
                set => timeFrameUnitField = value;
            }

            /// <remarks/>
            public dictionarySFType timeMvzUnit
            {
                get => timeMvzUnitField;
                set => timeMvzUnitField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("reasonsAdditionalInformation")]
            public dictionarySFType[] reasonsAdditionalInformation
            {
                get => reasonsAdditionalInformationField;
                set => reasonsAdditionalInformationField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("authorities")]
            public dictionarySFType[] authorities
            {
                get => authoritiesField;
                set => authoritiesField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class administrativeProceduresSFType
        {

            private string idField;

            private dictionarySFType nameField;

            private dictionarySFType timeFrameUnitField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public dictionarySFType name
            {
                get => nameField;
                set => nameField = value;
            }

            /// <remarks/>
            public dictionarySFType timeFrameUnit
            {
                get => timeFrameUnitField;
                set => timeFrameUnitField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class administrativeProceduresActionsSFType
        {

            private administrativeProceduresSFType[] administrativeProceduresField;

            private administrativeActionsSFType[] administrativeActionsField;

            private hookupType[] hookupField;

            private lanesType[] lanesField;

            /// <remarks/>
            [XmlElementAttribute("administrativeProcedures")]
            public administrativeProceduresSFType[] administrativeProcedures
            {
                get => administrativeProceduresField;
                set => administrativeProceduresField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("administrativeActions")]
            public administrativeActionsSFType[] administrativeActions
            {
                get => administrativeActionsField;
                set => administrativeActionsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("hookup")]
            public hookupType[] hookup
            {
                get => hookupField;
                set => hookupField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("lanes")]
            public lanesType[] lanes
            {
                get => lanesField;
                set => lanesField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class profilingAnswerProcedureSFType
        {

            private dictionarySFType admProcedureNameField;

            private dictionarySFType timeFrameUnitField;

            /// <remarks/>
            public dictionarySFType admProcedureName
            {
                get => admProcedureNameField;
                set => admProcedureNameField = value;
            }

            /// <remarks/>
            public dictionarySFType timeFrameUnit
            {
                get => timeFrameUnitField;
                set => timeFrameUnitField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class paymentOrderType
        {

            private fullEnumType calculationTypeField;

            private string paymentNameField;

            private fullEnumType paymentMethodField;

            private fullDictionaryType[] paymentTypesField;

            private string paymentAmountField;

            /// <remarks/>
            public fullEnumType calculationType
            {
                get => calculationTypeField;
                set => calculationTypeField = value;
            }

            /// <remarks/>
            public string paymentName
            {
                get => paymentNameField;
                set => paymentNameField = value;
            }

            /// <remarks/>
            public fullEnumType paymentMethod
            {
                get => paymentMethodField;
                set => paymentMethodField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("paymentTypes")]
            public fullDictionaryType[] paymentTypes
            {
                get => paymentTypesField;
                set => paymentTypesField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string paymentAmount
            {
                get => paymentAmountField;
                set => paymentAmountField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class fullEnumType
        {

            private string nameField;

            private string codeField;

            /// <remarks/>
            public string name
            {
                get => nameField;
                set => nameField = value;
            }

            /// <remarks/>
            public string code
            {
                get => codeField;
                set => codeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class paymentsSFType
        {

            private dictionaryNpaType paymentNpaField;

            private paymentOrderType[] paymentOrderField;

            private fullDictionaryType[] paymentOptionsField;

            /// <remarks/>
            public dictionaryNpaType paymentNpa
            {
                get => paymentNpaField;
                set => paymentNpaField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("paymentOrder")]
            public paymentOrderType[] paymentOrder
            {
                get => paymentOrderField;
                set => paymentOrderField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("paymentOptions")]
            public fullDictionaryType[] paymentOptions
            {
                get => paymentOptionsField;
                set => paymentOptionsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class dictionaryNpaType
        {

            private string idField;

            private string nameField;

            private string levelField;

            private string dictionaryCodeField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string name
            {
                get => nameField;
                set => nameField = value;
            }

            /// <remarks/>
            public string level
            {
                get => levelField;
                set => levelField = value;
            }

            /// <remarks/>
            public string dictionaryCode
            {
                get => dictionaryCodeField;
                set => dictionaryCodeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class actionsType
        {

            private fullDictionaryType applyChannelField;

            private fullDictionaryType[] documentActionsField;

            /// <remarks/>
            public fullDictionaryType applyChannel
            {
                get => applyChannelField;
                set => applyChannelField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("documentActions")]
            public fullDictionaryType[] documentActions
            {
                get => documentActionsField;
                set => documentActionsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class documentsDSFType
        {

            private dictionarySFType documentField;

            private bool isAddInfoInProcessField;

            private bool isAddInfoInProcessFieldSpecified;

            private bool isNotStructuredField;

            private bool isNotStructuredFieldSpecified;

            private actionsType[] actionsField;

            private admProceduresSFType[] admProceduresField;

            private attributeSettingsSFType[] attributeSettingsField;

            private criteriaSFType[] criteriaField;

            /// <remarks/>
            public dictionarySFType document
            {
                get => documentField;
                set => documentField = value;
            }

            /// <remarks/>
            public bool isAddInfoInProcess
            {
                get => isAddInfoInProcessField;
                set => isAddInfoInProcessField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isAddInfoInProcessSpecified
            {
                get => isAddInfoInProcessFieldSpecified;
                set => isAddInfoInProcessFieldSpecified = value;
            }

            /// <remarks/>
            public bool isNotStructured
            {
                get => isNotStructuredField;
                set => isNotStructuredField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isNotStructuredSpecified
            {
                get => isNotStructuredFieldSpecified;
                set => isNotStructuredFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("actions")]
            public actionsType[] actions
            {
                get => actionsField;
                set => actionsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("admProcedures")]
            public admProceduresSFType[] admProcedures
            {
                get => admProceduresField;
                set => admProceduresField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeSettings")]
            public attributeSettingsSFType[] attributeSettings
            {
                get => attributeSettingsField;
                set => attributeSettingsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("criteria")]
            public criteriaSFType[] criteria
            {
                get => criteriaField;
                set => criteriaField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class admProceduresSFType
        {

            private dictionarySFType admProcedureField;

            private dictionarySFType unitsOfMeasurementField;

            /// <remarks/>
            public dictionarySFType admProcedure
            {
                get => admProcedureField;
                set => admProcedureField = value;
            }

            /// <remarks/>
            public dictionarySFType unitsOfMeasurement
            {
                get => unitsOfMeasurementField;
                set => unitsOfMeasurementField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class attributeSettingsSFType
        {

            private dictionaryAtrType attributeField;

            private bool isDecisionMakingField;

            private bool isDecisionMakingFieldSpecified;

            private bool isRegistryEntryField;

            private bool isRegistryEntryFieldSpecified;

            private bool isAssessmentProcedureField;

            private bool isAssessmentProcedureFieldSpecified;

            private bool isInterdepartmentalInteractionField;

            private bool isInterdepartmentalInteractionFieldSpecified;

            private bool isInteractionWithApplicantField;

            private bool isInteractionWithApplicantFieldSpecified;

            /// <remarks/>
            public dictionaryAtrType attribute
            {
                get => attributeField;
                set => attributeField = value;
            }

            /// <remarks/>
            public bool isDecisionMaking
            {
                get => isDecisionMakingField;
                set => isDecisionMakingField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isDecisionMakingSpecified
            {
                get => isDecisionMakingFieldSpecified;
                set => isDecisionMakingFieldSpecified = value;
            }

            /// <remarks/>
            public bool isRegistryEntry
            {
                get => isRegistryEntryField;
                set => isRegistryEntryField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isRegistryEntrySpecified
            {
                get => isRegistryEntryFieldSpecified;
                set => isRegistryEntryFieldSpecified = value;
            }

            /// <remarks/>
            public bool isAssessmentProcedure
            {
                get => isAssessmentProcedureField;
                set => isAssessmentProcedureField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isAssessmentProcedureSpecified
            {
                get => isAssessmentProcedureFieldSpecified;
                set => isAssessmentProcedureFieldSpecified = value;
            }

            /// <remarks/>
            public bool isInterdepartmentalInteraction
            {
                get => isInterdepartmentalInteractionField;
                set => isInterdepartmentalInteractionField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isInterdepartmentalInteractionSpecified
            {
                get => isInterdepartmentalInteractionFieldSpecified;
                set => isInterdepartmentalInteractionFieldSpecified = value;
            }

            /// <remarks/>
            public bool isInteractionWithApplicant
            {
                get => isInteractionWithApplicantField;
                set => isInteractionWithApplicantField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isInteractionWithApplicantSpecified
            {
                get => isInteractionWithApplicantFieldSpecified;
                set => isInteractionWithApplicantFieldSpecified = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class dictionaryAtrType
        {

            private string idField;

            private string attributeTypeField;

            private string dictionaryCodeField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string attributeType
            {
                get => attributeTypeField;
                set => attributeTypeField = value;
            }

            /// <remarks/>
            public string dictionaryCode
            {
                get => dictionaryCodeField;
                set => dictionaryCodeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class criteriaSFType
        {

            private dictionarySFType criterionField;

            private dictionarySFType decisionTypeField;

            private fullDictionaryType checkTypeField;

            private dictionarySFType rejectionReasonField;

            private fullDictionaryType[] provisionTypesField;

            private bool isRejectionReasonField;

            private bool isRejectionReasonFieldSpecified;

            private dictionarySFType[] documentRequirementsField;

            private string rulesCriteriaField;

            private string rulesResumeField;

            private bool isRulesCriteriaInResumeField;

            private bool isRulesCriteriaInResumeFieldSpecified;

            private criteriaAdmProcedureType[] criteriaAdmProcedureField;

            /// <remarks/>
            public dictionarySFType criterion
            {
                get => criterionField;
                set => criterionField = value;
            }

            /// <remarks/>
            public dictionarySFType decisionType
            {
                get => decisionTypeField;
                set => decisionTypeField = value;
            }

            /// <remarks/>
            public fullDictionaryType checkType
            {
                get => checkTypeField;
                set => checkTypeField = value;
            }

            /// <remarks/>
            public dictionarySFType rejectionReason
            {
                get => rejectionReasonField;
                set => rejectionReasonField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("provisionTypes")]
            public fullDictionaryType[] provisionTypes
            {
                get => provisionTypesField;
                set => provisionTypesField = value;
            }

            /// <remarks/>
            public bool isRejectionReason
            {
                get => isRejectionReasonField;
                set => isRejectionReasonField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isRejectionReasonSpecified
            {
                get => isRejectionReasonFieldSpecified;
                set => isRejectionReasonFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("documentRequirements")]
            public dictionarySFType[] documentRequirements
            {
                get => documentRequirementsField;
                set => documentRequirementsField = value;
            }

            /// <remarks/>
            public string rulesCriteria
            {
                get => rulesCriteriaField;
                set => rulesCriteriaField = value;
            }

            /// <remarks/>
            public string rulesResume
            {
                get => rulesResumeField;
                set => rulesResumeField = value;
            }

            /// <remarks/>
            public bool isRulesCriteriaInResume
            {
                get => isRulesCriteriaInResumeField;
                set => isRulesCriteriaInResumeField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isRulesCriteriaInResumeSpecified
            {
                get => isRulesCriteriaInResumeFieldSpecified;
                set => isRulesCriteriaInResumeFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("criteriaAdmProcedure")]
            public criteriaAdmProcedureType[] criteriaAdmProcedure
            {
                get => criteriaAdmProcedureField;
                set => criteriaAdmProcedureField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class criteriaAdmProcedureType
        {

            private dictionaryNFType admProcedureIdField;

            private string deadlineField;

            private dictionaryNFType unitsOfMeasurementIdField;

            private string serialNumberField;

            private bool isRequiredField;

            private bool isRequiredFieldSpecified;

            /// <remarks/>
            public dictionaryNFType admProcedureId
            {
                get => admProcedureIdField;
                set => admProcedureIdField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string deadline
            {
                get => deadlineField;
                set => deadlineField = value;
            }

            /// <remarks/>
            public dictionaryNFType unitsOfMeasurementId
            {
                get => unitsOfMeasurementIdField;
                set => unitsOfMeasurementIdField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string serialNumber
            {
                get => serialNumberField;
                set => serialNumberField = value;
            }

            /// <remarks/>
            public bool isRequired
            {
                get => isRequiredField;
                set => isRequiredField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isRequiredSpecified
            {
                get => isRequiredFieldSpecified;
                set => isRequiredFieldSpecified = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class dictionaryNFType
        {

            private string nameField;

            /// <remarks/>
            public string name
            {
                get => nameField;
                set => nameField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class documentsCategorySFType
        {

            private dictionarySFType documentCategoryField;

            private string numberOfDocumentsField;

            private fullDictionaryType[] requestChannelIdsField;

            private fullDictionaryType[] receivingСhannelIdsField;

            private bool isRequiredOptionalField;

            private bool isRequiredOptionalFieldSpecified;

            private documentsDSFType[] documentsField;

            /// <remarks/>
            public dictionarySFType documentCategory
            {
                get => documentCategoryField;
                set => documentCategoryField = value;
            }

            /// <remarks/>
            public string numberOfDocuments
            {
                get => numberOfDocumentsField;
                set => numberOfDocumentsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("requestChannelIds")]
            public fullDictionaryType[] requestChannelIds
            {
                get => requestChannelIdsField;
                set => requestChannelIdsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("receivingСhannelIds")]
            public fullDictionaryType[] receivingСhannelIds
            {
                get => receivingСhannelIdsField;
                set => receivingСhannelIdsField = value;
            }

            /// <remarks/>
            public bool isRequiredOptional
            {
                get => isRequiredOptionalField;
                set => isRequiredOptionalField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isRequiredOptionalSpecified
            {
                get => isRequiredOptionalFieldSpecified;
                set => isRequiredOptionalFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("documents")]
            public documentsDSFType[] documents
            {
                get => documentsField;
                set => documentsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class requestNoSmevSFType
        {

            private string idField;

            private dictionarySFType ownerServiceField;

            private string dictionaryCodeField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public dictionarySFType ownerService
            {
                get => ownerServiceField;
                set => ownerServiceField = value;
            }

            /// <remarks/>
            public string dictionaryCode
            {
                get => dictionaryCodeField;
                set => dictionaryCodeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class requestsNoSmevSFType
        {

            private requestNoSmevSFType requestField;

            private fullDictionaryType[] requestMethodIdsField;

            private dictionarySFType reasonServiceField;

            private dictionarySFType timeRequestMeasureField;

            private dictionarySFType timeResponseMeasureField;

            private criteriaSFType[] criteriaField;

            private admProceduresSFType[] admProceduresField;

            private attributeRequestsSFType[] attributeRequestsField;

            private attributeResponsesSFType[] attributeResponsesField;

            /// <remarks/>
            public requestNoSmevSFType request
            {
                get => requestField;
                set => requestField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("requestMethodIds")]
            public fullDictionaryType[] requestMethodIds
            {
                get => requestMethodIdsField;
                set => requestMethodIdsField = value;
            }

            /// <remarks/>
            public dictionarySFType reasonService
            {
                get => reasonServiceField;
                set => reasonServiceField = value;
            }

            /// <remarks/>
            public dictionarySFType timeRequestMeasure
            {
                get => timeRequestMeasureField;
                set => timeRequestMeasureField = value;
            }

            /// <remarks/>
            public dictionarySFType timeResponseMeasure
            {
                get => timeResponseMeasureField;
                set => timeResponseMeasureField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("criteria")]
            public criteriaSFType[] criteria
            {
                get => criteriaField;
                set => criteriaField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("admProcedures")]
            public admProceduresSFType[] admProcedures
            {
                get => admProceduresField;
                set => admProceduresField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeRequests")]
            public attributeRequestsSFType[] attributeRequests
            {
                get => attributeRequestsField;
                set => attributeRequestsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeResponses")]
            public attributeResponsesSFType[] attributeResponses
            {
                get => attributeResponsesField;
                set => attributeResponsesField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class attributeRequestsSFType
        {

            private dictionaryAtrType attributeField;

            /// <remarks/>
            public dictionaryAtrType attribute
            {
                get => attributeField;
                set => attributeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class attributeResponsesSFType
        {

            private dictionaryAtrType attributeField;

            /// <remarks/>
            public dictionaryAtrType attribute
            {
                get => attributeField;
                set => attributeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class request3SFType
        {

            private string idField;

            private string idRequestField;

            private dictionarySFType ownerServiceField;

            private string versionServiceField;

            private string linkServiceField;

            private string namespaceServiceField;

            private string dictionaryCodeField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string idRequest
            {
                get => idRequestField;
                set => idRequestField = value;
            }

            /// <remarks/>
            public dictionarySFType ownerService
            {
                get => ownerServiceField;
                set => ownerServiceField = value;
            }

            /// <remarks/>
            public string versionService
            {
                get => versionServiceField;
                set => versionServiceField = value;
            }

            /// <remarks/>
            public string linkService
            {
                get => linkServiceField;
                set => linkServiceField = value;
            }

            /// <remarks/>
            public string namespaceService
            {
                get => namespaceServiceField;
                set => namespaceServiceField = value;
            }

            /// <remarks/>
            public string dictionaryCode
            {
                get => dictionaryCodeField;
                set => dictionaryCodeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class requests3SFType
        {

            private request3SFType requestField;

            private dictionarySFType reasonServiceField;

            private dictionarySFType timeRequestMeasureField;

            private dictionarySFType timeResponseMeasureField;

            private criteriaSFType[] criteriaField;

            private admProceduresSFType[] admProceduresField;

            private attributeRequestsSFType[] attributeRequestsField;

            private attributeResponsesSFType[] attributeResponsesField;

            /// <remarks/>
            public request3SFType request
            {
                get => requestField;
                set => requestField = value;
            }

            /// <remarks/>
            public dictionarySFType reasonService
            {
                get => reasonServiceField;
                set => reasonServiceField = value;
            }

            /// <remarks/>
            public dictionarySFType timeRequestMeasure
            {
                get => timeRequestMeasureField;
                set => timeRequestMeasureField = value;
            }

            /// <remarks/>
            public dictionarySFType timeResponseMeasure
            {
                get => timeResponseMeasureField;
                set => timeResponseMeasureField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("criteria")]
            public criteriaSFType[] criteria
            {
                get => criteriaField;
                set => criteriaField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("admProcedures")]
            public admProceduresSFType[] admProcedures
            {
                get => admProceduresField;
                set => admProceduresField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeRequests")]
            public attributeRequestsSFType[] attributeRequests
            {
                get => attributeRequestsField;
                set => attributeRequestsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeResponses")]
            public attributeResponsesSFType[] attributeResponses
            {
                get => attributeResponsesField;
                set => attributeResponsesField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class requestsSFType
        {

            private dictionarySFType requestField;

            private dictionarySFType reasonServiceField;

            private dictionarySFType timeRequestMeasureField;

            private dictionarySFType timeResponseMeasureField;

            private criteriaSFType[] criteriaField;

            private admProceduresSFType[] admProceduresField;

            private attributeRequestsSFType[] attributeRequestsField;

            private attributeResponsesSFType[] attributeResponsesField;

            /// <remarks/>
            public dictionarySFType request
            {
                get => requestField;
                set => requestField = value;
            }

            /// <remarks/>
            public dictionarySFType reasonService
            {
                get => reasonServiceField;
                set => reasonServiceField = value;
            }

            /// <remarks/>
            public dictionarySFType timeRequestMeasure
            {
                get => timeRequestMeasureField;
                set => timeRequestMeasureField = value;
            }

            /// <remarks/>
            public dictionarySFType timeResponseMeasure
            {
                get => timeResponseMeasureField;
                set => timeResponseMeasureField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("criteria")]
            public criteriaSFType[] criteria
            {
                get => criteriaField;
                set => criteriaField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("admProcedures")]
            public admProceduresSFType[] admProcedures
            {
                get => admProceduresField;
                set => admProceduresField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeRequests")]
            public attributeRequestsSFType[] attributeRequests
            {
                get => attributeRequestsField;
                set => attributeRequestsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeResponses")]
            public attributeResponsesSFType[] attributeResponses
            {
                get => attributeResponsesField;
                set => attributeResponsesField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class serviceSFType
        {

            private string idField;

            private string nameField;

            private string idServiceField;

            private dictionarySFType ownerServiceField;

            private string versionServiceField;

            private string linkServiceField;

            private string dictionaryCodeField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string name
            {
                get => nameField;
                set => nameField = value;
            }

            /// <remarks/>
            public string idService
            {
                get => idServiceField;
                set => idServiceField = value;
            }

            /// <remarks/>
            public dictionarySFType ownerService
            {
                get => ownerServiceField;
                set => ownerServiceField = value;
            }

            /// <remarks/>
            public string versionService
            {
                get => versionServiceField;
                set => versionServiceField = value;
            }

            /// <remarks/>
            public string linkService
            {
                get => linkServiceField;
                set => linkServiceField = value;
            }

            /// <remarks/>
            public string dictionaryCode
            {
                get => dictionaryCodeField;
                set => dictionaryCodeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class smevServiceSFType
        {

            private serviceSFType serviceField;

            private requestsSFType[] requestsField;

            /// <remarks/>
            public serviceSFType service
            {
                get => serviceField;
                set => serviceField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("requests")]
            public requestsSFType[] requests
            {
                get => requestsField;
                set => requestsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class smev2SFType
        {

            private smevServiceSFType smevServiceField;

            /// <remarks/>
            public smevServiceSFType smevService
            {
                get => smevServiceField;
                set => smevServiceField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class interdepartmentalRequestSFType
        {

            private smev2SFType[] smev2Field;

            //private requests3SFType[][] smev3Field;
            private object2Type[] smev3Field;

            //private requestsNoSmevSFType[][] noSmevField;
            private object4Type[] noSmevField;

            /// <remarks/>
            [XmlElementAttribute("smev2")]
            public smev2SFType[] smev2
            {
                get => smev2Field;
                set => smev2Field = value;
            }

            /// <remarks/>
            //[XmlArrayItemAttribute("requests", typeof(requests3SFType), IsNullable = false)]
            [XmlElement("smev3")]
            public object2Type[] smev3
            {
                get => smev3Field;
                set => smev3Field = value;
            }

            /// <remarks/>
            //[XmlArrayItemAttribute("requests", typeof(requestsNoSmevSFType), IsNullable = false)]
            [XmlElement("noSmev")]
            public object4Type[] noSmev
            {
                get => noSmevField;
                set => noSmevField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class additionalInformationsSFType
        {

            private dictionarySFType infoTypeField;

            private string dataSourceField;

            private bool isRequiredOptionalField;

            private bool isRequiredOptionalFieldSpecified;

            private bool isAddInfoInProcessField;

            private bool isAddInfoInProcessFieldSpecified;

            private fullDictionaryType[] requestChannelIdsField;

            private fullDictionaryType[] receivingСhannelIdsField;

            private admProceduresSFType[] admProceduresField;

            private attributeSettingsSFType[] attributeSettingsField;

            private criteriaSFType[] criteriaField;

            /// <remarks/>
            public dictionarySFType infoType
            {
                get => infoTypeField;
                set => infoTypeField = value;
            }

            /// <remarks/>
            public string dataSource
            {
                get => dataSourceField;
                set => dataSourceField = value;
            }

            /// <remarks/>
            public bool isRequiredOptional
            {
                get => isRequiredOptionalField;
                set => isRequiredOptionalField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isRequiredOptionalSpecified
            {
                get => isRequiredOptionalFieldSpecified;
                set => isRequiredOptionalFieldSpecified = value;
            }

            /// <remarks/>
            public bool isAddInfoInProcess
            {
                get => isAddInfoInProcessField;
                set => isAddInfoInProcessField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isAddInfoInProcessSpecified
            {
                get => isAddInfoInProcessFieldSpecified;
                set => isAddInfoInProcessFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("requestChannelIds")]
            public fullDictionaryType[] requestChannelIds
            {
                get => requestChannelIdsField;
                set => requestChannelIdsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("receivingСhannelIds")]
            public fullDictionaryType[] receivingСhannelIds
            {
                get => receivingСhannelIdsField;
                set => receivingСhannelIdsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("admProcedures")]
            public admProceduresSFType[] admProcedures
            {
                get => admProceduresField;
                set => admProceduresField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeSettings")]
            public attributeSettingsSFType[] attributeSettings
            {
                get => attributeSettingsField;
                set => attributeSettingsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("criteria")]
            public criteriaSFType[] criteria
            {
                get => criteriaField;
                set => criteriaField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class answersSFType
        {

            private string answerСontainerIdField;

            private string idField;

            private bool isInitialEventField;

            private bool isInitialEventFieldSpecified;

            private string codeAnswerField;

            private dictionarySFType typicalAnswerField;

            private string[] questionsIdField;

            private additionalInformationsSFType[] additionalInformationsField;

            private interdepartmentalRequestSFType interdepartmentalRequestField;

            //private documentsCategorySFType[][] documentsField;
            private object1Type[] documentsField;

            private paymentsSFType paymentsField;

            private profilingAnswerProcedureSFType[] profilingAnswerProcedureField;

            /// <remarks/>
            public string answerСontainerId
            {
                get => answerСontainerIdField;
                set => answerСontainerIdField = value;
            }

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public bool isInitialEvent
            {
                get => isInitialEventField;
                set => isInitialEventField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isInitialEventSpecified
            {
                get => isInitialEventFieldSpecified;
                set => isInitialEventFieldSpecified = value;
            }

            /// <remarks/>
            public string codeAnswer
            {
                get => codeAnswerField;
                set => codeAnswerField = value;
            }

            /// <remarks/>
            public dictionarySFType typicalAnswer
            {
                get => typicalAnswerField;
                set => typicalAnswerField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("questionsId", DataType = "integer")]
            public string[] questionsId
            {
                get => questionsIdField;
                set => questionsIdField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("additionalInformations")]
            public additionalInformationsSFType[] additionalInformations
            {
                get => additionalInformationsField;
                set => additionalInformationsField = value;
            }

            /// <remarks/>
            public interdepartmentalRequestSFType interdepartmentalRequest
            {
                get => interdepartmentalRequestField;
                set => interdepartmentalRequestField = value;
            }

            /// <remarks/>
            //[XmlArrayItemAttribute("documentsCategory", typeof(documentsCategorySFType), IsNullable = false)]
            [XmlElement("documents")]
            public object1Type[] documents
            {
                get => documentsField;
                set => documentsField = value;
            }

            /// <remarks/>
            public paymentsSFType payments
            {
                get => paymentsField;
                set => paymentsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("profilingAnswerProcedure")]
            public profilingAnswerProcedureSFType[] profilingAnswerProcedure
            {
                get => profilingAnswerProcedureField;
                set => profilingAnswerProcedureField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class questionsSFType
        {

            private string questionСontainerIdField;

            private string idField;

            private string codeQuestionField;

            private dictionarySFType typicalQuestionField;

            private string[] answersIdField;

            private string parentIdField;

            private string[] targetQuestionField;

            /// <remarks/>
            public string questionСontainerId
            {
                get => questionСontainerIdField;
                set => questionСontainerIdField = value;
            }

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string codeQuestion
            {
                get => codeQuestionField;
                set => codeQuestionField = value;
            }

            /// <remarks/>
            public dictionarySFType typicalQuestion
            {
                get => typicalQuestionField;
                set => typicalQuestionField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("answersId", DataType = "integer")]
            public string[] answersId
            {
                get => answersIdField;
                set => answersIdField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string parentId
            {
                get => parentIdField;
                set => parentIdField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("targetQuestion")]
            public string[] targetQuestion
            {
                get => targetQuestionField;
                set => targetQuestionField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class profilingSettingsSFType
        {

            private questionsSFType[] questionsField;

            private answersSFType[] answersField;

            /// <remarks/>
            [XmlElementAttribute("questions")]
            public questionsSFType[] questions
            {
                get => questionsField;
                set => questionsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("answers")]
            public answersSFType[] answers
            {
                get => answersField;
                set => answersField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class expertProcedureResultsTimeType
        {

            private string expertProcedureResultTimingField;

            private fullDictionaryType expertProcedureResultTimingUnitField;

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string expertProcedureResultTiming
            {
                get => expertProcedureResultTimingField;
                set => expertProcedureResultTimingField = value;
            }

            /// <remarks/>
            public fullDictionaryType expertProcedureResultTimingUnit
            {
                get => expertProcedureResultTimingUnitField;
                set => expertProcedureResultTimingUnitField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class expertProcedurePlacesType
        {

            private bool hasexpertProcedurePlaceField;

            private bool hasexpertProcedurePlaceFieldSpecified;

            private string expertProcedurePlaceFrameField;

            private fullDictionaryType expertProcedurePlaceFrameUnitField;

            /// <remarks/>
            public bool hasexpertProcedurePlace
            {
                get => hasexpertProcedurePlaceField;
                set => hasexpertProcedurePlaceField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool hasexpertProcedurePlaceSpecified
            {
                get => hasexpertProcedurePlaceFieldSpecified;
                set => hasexpertProcedurePlaceFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string expertProcedurePlaceFrame
            {
                get => expertProcedurePlaceFrameField;
                set => expertProcedurePlaceFrameField = value;
            }

            /// <remarks/>
            public fullDictionaryType expertProcedurePlaceFrameUnit
            {
                get => expertProcedurePlaceFrameUnitField;
                set => expertProcedurePlaceFrameUnitField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class expertProcedureTimesType
        {

            private bool hasexpertProcedureTimeField;

            private bool hasexpertProcedureTimeFieldSpecified;

            private string expertProcedureTimeFrameField;

            private fullDictionaryType expertProcedureTimeFrameUnitField;

            /// <remarks/>
            public bool hasexpertProcedureTime
            {
                get => hasexpertProcedureTimeField;
                set => hasexpertProcedureTimeField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool hasexpertProcedureTimeSpecified
            {
                get => hasexpertProcedureTimeFieldSpecified;
                set => hasexpertProcedureTimeFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string expertProcedureTimeFrame
            {
                get => expertProcedureTimeFrameField;
                set => expertProcedureTimeFrameField = value;
            }

            /// <remarks/>
            public fullDictionaryType expertProcedureTimeFrameUnit
            {
                get => expertProcedureTimeFrameUnitField;
                set => expertProcedureTimeFrameUnitField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class expertProcedureResultsSFType
        {

            private dictionarySFType procedureResultField;

            /// <remarks/>
            public dictionarySFType ProcedureResult
            {
                get => procedureResultField;
                set => procedureResultField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class expertProcedureSettingsSFType
        {

            private dictionarySFType expertProcedureTypeField;

            private dictionarySFType[] expertProcedurePurposeField;

            private dictionarySFType[] expertProcedureObjectField;

            private dictionarySFType expertProcedureDurationUnitField;

            private dictionarySFType[] expertProcedureOrganizationsField;

            private dictionarySFType[] expertProcedureMinorOrganizationsField;

            private expertProcedureResultsSFType[] expertProcedureResultsField;

            private dictionaryNpaType[] expertProcedureNpasField;

            private expertProcedureTimesType[] expertProcedureTimesField;

            private expertProcedurePlacesType[] expertProcedurePlacesField;

            private expertProcedureResultsTimeType[] expertProcedureResultsTimeField;

            private bool expertProcedureApplicantField;

            private bool expertProcedureApplicantFieldSpecified;

            /// <remarks/>
            public dictionarySFType expertProcedureType
            {
                get => expertProcedureTypeField;
                set => expertProcedureTypeField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedurePurpose")]
            public dictionarySFType[] expertProcedurePurpose
            {
                get => expertProcedurePurposeField;
                set => expertProcedurePurposeField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedureObject")]
            public dictionarySFType[] expertProcedureObject
            {
                get => expertProcedureObjectField;
                set => expertProcedureObjectField = value;
            }

            /// <remarks/>
            public dictionarySFType expertProcedureDurationUnit
            {
                get => expertProcedureDurationUnitField;
                set => expertProcedureDurationUnitField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedureOrganizations")]
            public dictionarySFType[] expertProcedureOrganizations
            {
                get => expertProcedureOrganizationsField;
                set => expertProcedureOrganizationsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedureMinorOrganizations")]
            public dictionarySFType[] expertProcedureMinorOrganizations
            {
                get => expertProcedureMinorOrganizationsField;
                set => expertProcedureMinorOrganizationsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedureResults")]
            public expertProcedureResultsSFType[] expertProcedureResults
            {
                get => expertProcedureResultsField;
                set => expertProcedureResultsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedureNpas")]
            public dictionaryNpaType[] expertProcedureNpas
            {
                get => expertProcedureNpasField;
                set => expertProcedureNpasField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedureTimes")]
            public expertProcedureTimesType[] expertProcedureTimes
            {
                get => expertProcedureTimesField;
                set => expertProcedureTimesField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedurePlaces")]
            public expertProcedurePlacesType[] expertProcedurePlaces
            {
                get => expertProcedurePlacesField;
                set => expertProcedurePlacesField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedureResultsTime")]
            public expertProcedureResultsTimeType[] expertProcedureResultsTime
            {
                get => expertProcedureResultsTimeField;
                set => expertProcedureResultsTimeField = value;
            }

            /// <remarks/>
            public bool expertProcedureApplicant
            {
                get => expertProcedureApplicantField;
                set => expertProcedureApplicantField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool expertProcedureApplicantSpecified
            {
                get => expertProcedureApplicantFieldSpecified;
                set => expertProcedureApplicantFieldSpecified = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class resourceConstraintSFType
        {

            private dictionarySFType constraintField;

            private dictionarySFType resourceConstraintObjectIdField;

            private dictionaryNpaType[] resourceConstraintsNpaField;

            /// <remarks/>
            public dictionarySFType Constraint
            {
                get => constraintField;
                set => constraintField = value;
            }

            /// <remarks/>
            public dictionarySFType resourceConstraintObjectId
            {
                get => resourceConstraintObjectIdField;
                set => resourceConstraintObjectIdField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resourceConstraintsNpa")]
            public dictionaryNpaType[] resourceConstraintsNpa
            {
                get => resourceConstraintsNpaField;
                set => resourceConstraintsNpaField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class resultDocumentSettingsSFType
        {

            private dictionarySFType resultDocumentField;

            private dictionarySFType[] resultDocumentFormsField;

            /// <remarks/>
            public dictionarySFType resultDocument
            {
                get => resultDocumentField;
                set => resultDocumentField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultDocumentForms")]
            public dictionarySFType[] resultDocumentForms
            {
                get => resultDocumentFormsField;
                set => resultDocumentFormsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class resultsInfoSFType
        {

            private dictionarySFType resultNameField;

            private resultDocumentSettingsSFType[] resultDocumentSettingsField;

            private dictionarySFType[] resultObjectsField;

            private dictionarySFType[] resultSolutionAttributesField;

            private dictionarySFType resultRegistryField;

            private dictionarySFType[] resultRegistryAttributesField;

            private dictionarySFType resultSystemField;

            private dictionarySFType resultRegistryActionField;

            private dictionarySFType[] resultChannelsField;

            /// <remarks/>
            public dictionarySFType resultName
            {
                get => resultNameField;
                set => resultNameField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultDocumentSettings")]
            public resultDocumentSettingsSFType[] resultDocumentSettings
            {
                get => resultDocumentSettingsField;
                set => resultDocumentSettingsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultObjects")]
            public dictionarySFType[] resultObjects
            {
                get => resultObjectsField;
                set => resultObjectsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultSolutionAttributes")]
            public dictionarySFType[] resultSolutionAttributes
            {
                get => resultSolutionAttributesField;
                set => resultSolutionAttributesField = value;
            }

            /// <remarks/>
            public dictionarySFType resultRegistry
            {
                get => resultRegistryField;
                set => resultRegistryField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultRegistryAttributes")]
            public dictionarySFType[] resultRegistryAttributes
            {
                get => resultRegistryAttributesField;
                set => resultRegistryAttributesField = value;
            }

            /// <remarks/>
            public dictionarySFType resultSystem
            {
                get => resultSystemField;
                set => resultSystemField = value;
            }

            /// <remarks/>
            public dictionarySFType resultRegistryAction
            {
                get => resultRegistryActionField;
                set => resultRegistryActionField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultChannels")]
            public dictionarySFType[] resultChannels
            {
                get => resultChannelsField;
                set => resultChannelsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class resultsSFType
        {

            private dictionarySFType resultAmountField;

            private resultsInfoSFType[] resultsInfoField;

            /// <remarks/>
            public dictionarySFType resultAmount
            {
                get => resultAmountField;
                set => resultAmountField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultsInfo")]
            public resultsInfoSFType[] resultsInfo
            {
                get => resultsInfoField;
                set => resultsInfoField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class prerecordingMethodType
        {

            private fullDictionaryType prerecordingMethodField;

            /// <remarks/>
            public fullDictionaryType prerecordingMethod
            {
                get => prerecordingMethodField;
                set => prerecordingMethodField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class preRecordSettingsType
        {

            private bool preRecordApplicationField;

            private bool preRecordApplicationFieldSpecified;

            private prerecordingMethodType[] preRecordApplicationMethodsField;

            private bool preRecordResultField;

            private bool preRecordResultFieldSpecified;

            private prerecordingMethodType[] preRecordResultMethodsField;

            private bool preRecordAdministrativeProcedureField;

            private bool preRecordAdministrativeProcedureFieldSpecified;

            private prerecordingMethodType[] preRecordAdministrativeProceduresField;

            /// <remarks/>
            public bool preRecordApplication
            {
                get => preRecordApplicationField;
                set => preRecordApplicationField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool preRecordApplicationSpecified
            {
                get => preRecordApplicationFieldSpecified;
                set => preRecordApplicationFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("preRecordApplicationMethods")]
            public prerecordingMethodType[] preRecordApplicationMethods
            {
                get => preRecordApplicationMethodsField;
                set => preRecordApplicationMethodsField = value;
            }

            /// <remarks/>
            public bool preRecordResult
            {
                get => preRecordResultField;
                set => preRecordResultField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool preRecordResultSpecified
            {
                get => preRecordResultFieldSpecified;
                set => preRecordResultFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("preRecordResultMethods")]
            public prerecordingMethodType[] preRecordResultMethods
            {
                get => preRecordResultMethodsField;
                set => preRecordResultMethodsField = value;
            }

            /// <remarks/>
            public bool preRecordAdministrativeProcedure
            {
                get => preRecordAdministrativeProcedureField;
                set => preRecordAdministrativeProcedureField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool preRecordAdministrativeProcedureSpecified
            {
                get => preRecordAdministrativeProcedureFieldSpecified;
                set => preRecordAdministrativeProcedureFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("preRecordAdministrativeProcedures")]
            public prerecordingMethodType[] preRecordAdministrativeProcedures
            {
                get => preRecordAdministrativeProceduresField;
                set => preRecordAdministrativeProceduresField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class periodRegistrationSFType
        {

            private dictionarySFType maxPeriodOfProvidingMeasureField;

            /// <remarks/>
            public dictionarySFType maxPeriodOfProvidingMeasure
            {
                get => maxPeriodOfProvidingMeasureField;
                set => maxPeriodOfProvidingMeasureField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class resultChannelsSFType
        {

            private dictionarySFType channelField;

            /// <remarks/>
            public dictionarySFType channel
            {
                get => channelField;
                set => channelField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class requestChannelsSFType
        {

            private dictionarySFType channelField;

            private bool hasMfcRefuseField;

            private bool hasMfcRefuseFieldSpecified;

            private dictionarySFType[] identifyMethodsField;

            private dictionarySFType[] applicantsField;

            /// <remarks/>
            public dictionarySFType channel
            {
                get => channelField;
                set => channelField = value;
            }

            /// <remarks/>
            public bool hasMfcRefuse
            {
                get => hasMfcRefuseField;
                set => hasMfcRefuseField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool hasMfcRefuseSpecified
            {
                get => hasMfcRefuseFieldSpecified;
                set => hasMfcRefuseFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("identifyMethods")]
            public dictionarySFType[] identifyMethods
            {
                get => identifyMethodsField;
                set => identifyMethodsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("applicants")]
            public dictionarySFType[] applicants
            {
                get => applicantsField;
                set => applicantsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class channelsSFType
        {

            private bool uniqueChannelsField;

            private bool uniqueChannelsFieldSpecified;

            private requestChannelsSFType[] requestChannelsField;

            private resultChannelsSFType[] resultChannelsField;

            /// <remarks/>
            public bool uniqueChannels
            {
                get => uniqueChannelsField;
                set => uniqueChannelsField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool uniqueChannelsSpecified
            {
                get => uniqueChannelsFieldSpecified;
                set => uniqueChannelsFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("requestChannels")]
            public requestChannelsSFType[] requestChannels
            {
                get => requestChannelsField;
                set => requestChannelsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultChannels")]
            public resultChannelsSFType[] resultChannels
            {
                get => resultChannelsField;
                set => resultChannelsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class applicantCategoriesSFType
        {

            private dictionarySFType applicantField;

            private dictionarySFType[] agentTypesField;

            /// <remarks/>
            public dictionarySFType applicant
            {
                get => applicantField;
                set => applicantField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("agentTypes")]
            public dictionarySFType[] agentTypes
            {
                get => agentTypesField;
                set => agentTypesField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class overviewSubServicesSFType
        {

            private string idField;

            private string shortNameField;

            private fullDictionaryType[] lifeSituationsField;

            private fullDictionaryType[] udertopicsField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string shortName
            {
                get => shortNameField;
                set => shortNameField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("lifeSituations")]
            public fullDictionaryType[] lifeSituations
            {
                get => lifeSituationsField;
                set => lifeSituationsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("udertopics")]
            public fullDictionaryType[] udertopics
            {
                get => udertopicsField;
                set => udertopicsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class subServicesSFType
        {

            private overviewSubServicesSFType overviewField;

            private applicantCategoriesSFType[] applicantCategoriesField;

            private channelsSFType channelsField;

            private periodRegistrationSFType periodRegistrationField;

            private preRecordSettingsType preRecordSettingsField;

            private resultsSFType resultsField;

            private resourceConstraintSFType resourceConstraintField;

            private expertProcedureSettingsSFType[] expertProcedureField;

            private profilingSettingsSFType[] profilingField;

            private administrativeProceduresActionsSFType administrativeProceduresActionsField;

            private proactiveSFType proactiveField;

            /// <remarks/>
            public overviewSubServicesSFType overview
            {
                get => overviewField;
                set => overviewField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("applicantCategories")]
            public applicantCategoriesSFType[] applicantCategories
            {
                get => applicantCategoriesField;
                set => applicantCategoriesField = value;
            }

            /// <remarks/>
            public channelsSFType channels
            {
                get => channelsField;
                set => channelsField = value;
            }

            /// <remarks/>
            public periodRegistrationSFType periodRegistration
            {
                get => periodRegistrationField;
                set => periodRegistrationField = value;
            }

            /// <remarks/>
            public preRecordSettingsType preRecordSettings
            {
                get => preRecordSettingsField;
                set => preRecordSettingsField = value;
            }

            /// <remarks/>
            public resultsSFType results
            {
                get => resultsField;
                set => resultsField = value;
            }

            /// <remarks/>
            public resourceConstraintSFType resourceConstraint
            {
                get => resourceConstraintField;
                set => resourceConstraintField = value;
            }

            /// <remarks/>
            [XmlArrayItemAttribute("expertProcedureSettings", IsNullable = false)]
            public expertProcedureSettingsSFType[] expertProcedure
            {
                get => expertProcedureField;
                set => expertProcedureField = value;
            }

            /// <remarks/>
            [XmlArrayItemAttribute("profilingSettings", IsNullable = false)]
            public profilingSettingsSFType[] profiling
            {
                get => profilingField;
                set => profilingField = value;
            }

            /// <remarks/>
            public administrativeProceduresActionsSFType administrativeProceduresActions
            {
                get => administrativeProceduresActionsField;
                set => administrativeProceduresActionsField = value;
            }

            /// <remarks/>
            public proactiveSFType proactive
            {
                get => proactiveField;
                set => proactiveField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class pretrialComplaintsProcedureSettingsSFType
        {

            private dictionarySFType pretrialComplaintsProcedureField;

            /// <remarks/>
            public dictionarySFType pretrialComplaintsProcedure
            {
                get => pretrialComplaintsProcedureField;
                set => pretrialComplaintsProcedureField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class monitoringComplianceSFType
        {

            private dictionarySFType currentControlRoutineField;

            private dictionarySFType[] inspectionsField;

            private dictionarySFType[] executiveOfficerResponsibilitiesField;

            private dictionarySFType[] controlRequirementsField;

            /// <remarks/>
            public dictionarySFType currentControlRoutine
            {
                get => currentControlRoutineField;
                set => currentControlRoutineField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("inspections")]
            public dictionarySFType[] inspections
            {
                get => inspectionsField;
                set => inspectionsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("executiveOfficerResponsibilities")]
            public dictionarySFType[] executiveOfficerResponsibilities
            {
                get => executiveOfficerResponsibilitiesField;
                set => executiveOfficerResponsibilitiesField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("controlRequirements")]
            public dictionarySFType[] controlRequirements
            {
                get => controlRequirementsField;
                set => controlRequirementsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class servicesInfoType
        {

            private string idField;

            private string rguIdField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string rguId
            {
                get => rguIdField;
                set => rguIdField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class indicatorsSFType
        {

            private dictionarySFType[] availabilityField;

            private dictionarySFType[] qualityField;

            /// <remarks/>
            [XmlElementAttribute("Availability")]
            public dictionarySFType[] Availability
            {
                get => availabilityField;
                set => availabilityField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("Quality")]
            public dictionarySFType[] Quality
            {
                get => qualityField;
                set => qualityField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class internetAddressesType
        {

            private string rpguUrlField;

            private string epguUrlField;

            private string responsibleOrganizationUrlField;

            /// <remarks/>
            public string rpguUrl
            {
                get => rpguUrlField;
                set => rpguUrlField = value;
            }

            /// <remarks/>
            public string epguUrl
            {
                get => epguUrlField;
                set => epguUrlField = value;
            }

            /// <remarks/>
            public string responsibleOrganizationUrl
            {
                get => responsibleOrganizationUrlField;
                set => responsibleOrganizationUrlField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class informingOfficesType
        {

            private string idField;

            private string fullNameField;

            private string dictionaryCodeField;

            private fullDictionaryType[] addressField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string fullName
            {
                get => fullNameField;
                set => fullNameField = value;
            }

            /// <remarks/>
            public string dictionaryCode
            {
                get => dictionaryCodeField;
                set => dictionaryCodeField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("address")]
            public fullDictionaryType[] address
            {
                get => addressField;
                set => addressField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class informingProcedureType
        {

            private string responsibleOrganizationWebsiteField;

            private string callCenterPhoneNumberField;

            private string callCenterExtensionNumberField;

            private informingOfficesType[] informingOfficesField;

            private fullEnumType[] channelsField;

            /// <remarks/>
            public string responsibleOrganizationWebsite
            {
                get => responsibleOrganizationWebsiteField;
                set => responsibleOrganizationWebsiteField = value;
            }

            /// <remarks/>
            public string callCenterPhoneNumber
            {
                get => callCenterPhoneNumberField;
                set => callCenterPhoneNumberField = value;
            }

            /// <remarks/>
            public string callCenterExtensionNumber
            {
                get => callCenterExtensionNumberField;
                set => callCenterExtensionNumberField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("informingOffices")]
            public informingOfficesType[] informingOffices
            {
                get => informingOfficesField;
                set => informingOfficesField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("channels")]
            public fullEnumType[] channels
            {
                get => channelsField;
                set => channelsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class enumSFType
        {

            private string codeField;

            /// <remarks/>
            public string code
            {
                get => codeField;
                set => codeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class approvedSFType
        {

            private enumSFType approvingActTypeField;

            private dictionarySFType numberOfDaysUnitField;

            /// <remarks/>
            public enumSFType approvingActType
            {
                get => approvingActTypeField;
                set => approvingActTypeField = value;
            }

            /// <remarks/>
            public dictionarySFType numberOfDaysUnit
            {
                get => numberOfDaysUnitField;
                set => numberOfDaysUnitField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class additionalDetailsType
        {

            private string keywordsField;

            private fullDictionaryType[] lifeSituationsField;

            private fullDictionaryType[] undertopicsField;

            /// <remarks/>
            public string keywords
            {
                get => keywordsField;
                set => keywordsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("lifeSituations")]
            public fullDictionaryType[] lifeSituations
            {
                get => lifeSituationsField;
                set => lifeSituationsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("undertopics")]
            public fullDictionaryType[] undertopics
            {
                get => undertopicsField;
                set => undertopicsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class responsibleOrganizationDelegateAuthoritySFType
        {

            private fullDictionaryType[] delegateAuthorityTypeField;

            private dictionarySFType[] responsibleOrganizationProfilesField;

            /// <remarks/>
            [XmlElementAttribute("delegateAuthorityType")]
            public fullDictionaryType[] delegateAuthorityType
            {
                get => delegateAuthorityTypeField;
                set => delegateAuthorityTypeField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("responsibleOrganizationProfiles")]
            public dictionarySFType[] responsibleOrganizationProfiles
            {
                get => responsibleOrganizationProfilesField;
                set => responsibleOrganizationProfilesField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class fullDictionaryFullNameType
        {

            private string idField;

            private string fullNameField;

            private string dictionaryCodeField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string fullName
            {
                get => fullNameField;
                set => fullNameField = value;
            }

            /// <remarks/>
            public string dictionaryCode
            {
                get => dictionaryCodeField;
                set => dictionaryCodeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class responsibleOrganizationSelfAuthoritySFType
        {

            private dictionarySFType responsibleOrganizationField;

            private dictionarySFType[] responsibleEntitiesField;

            private fullDictionaryFullNameType responsibleVassalOrganizationsField;

            /// <remarks/>
            public dictionarySFType responsibleOrganization
            {
                get => responsibleOrganizationField;
                set => responsibleOrganizationField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("responsibleEntities")]
            public dictionarySFType[] responsibleEntities
            {
                get => responsibleEntitiesField;
                set => responsibleEntitiesField = value;
            }

            /// <remarks/>
            public fullDictionaryFullNameType responsibleVassalOrganizations
            {
                get => responsibleVassalOrganizationsField;
                set => responsibleVassalOrganizationsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class lightServiceType
        {

            private string idField;

            private string nameField;

            private string rguIdField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string name
            {
                get => nameField;
                set => nameField = value;
            }

            /// <remarks/>
            public string rguId
            {
                get => rguIdField;
                set => rguIdField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class serviceCardType
        {

            private string rguIdField;

            /// <remarks/>
            public string rguId
            {
                get => rguIdField;
                set => rguIdField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class overviewServiceSFType
        {

            private string idField;

            private string versionMajorField;

            private string versionMinorField;

            private serviceCardType serviceCardField;

            private lightServiceType lightServiceField;

            private string parentServiceIdField;

            private string serviceShortNameField;

            private dictionaryNpaType[] npaField;

            private fullDictionaryType serviceLevelField;

            private string authorityTypeField;

            private dictionarySFType arOwnerField;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string versionMajor
            {
                get => versionMajorField;
                set => versionMajorField = value;
            }

            /// <remarks/>
            public string versionMinor
            {
                get => versionMinorField;
                set => versionMinorField = value;
            }

            /// <remarks/>
            public serviceCardType serviceCard
            {
                get => serviceCardField;
                set => serviceCardField = value;
            }

            /// <remarks/>
            public lightServiceType lightService
            {
                get => lightServiceField;
                set => lightServiceField = value;
            }

            /// <remarks/>
            public string parentServiceId
            {
                get => parentServiceIdField;
                set => parentServiceIdField = value;
            }

            /// <remarks/>
            public string serviceShortName
            {
                get => serviceShortNameField;
                set => serviceShortNameField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("npa")]
            public dictionaryNpaType[] npa
            {
                get => npaField;
                set => npaField = value;
            }

            /// <remarks/>
            public fullDictionaryType serviceLevel
            {
                get => serviceLevelField;
                set => serviceLevelField = value;
            }

            /// <remarks/>
            public string authorityType
            {
                get => authorityTypeField;
                set => authorityTypeField = value;
            }

            /// <remarks/>
            public dictionarySFType arOwner
            {
                get => arOwnerField;
                set => arOwnerField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class secondaryFieldsType
        {

            private overviewServiceSFType overviewField;

            private responsibleOrganizationSelfAuthoritySFType[] responsibleOrganizationSelfAuthorityField;

            private responsibleOrganizationDelegateAuthoritySFType responsibleOrganizationDelegateAuthorityField;

            private additionalDetailsType additionalDetailsField;

            private approvedSFType approvedField;

            private informingProcedureType informingProcedureField;

            private internetAddressesType internetAddressesField;

            private indicatorsSFType indicatorsField;

            private dictionarySFType[] roomSettingsField;

            private servicesInfoType[] associatedServicesField;

            private monitoringComplianceSFType monitoringComplianceField;

            private pretrialComplaintsProcedureSettingsSFType pretrialComplaintsProcedureSettingsField;

            private subServicesSFType[] subServicesField;

            /// <remarks/>
            public overviewServiceSFType overview
            {
                get => overviewField;
                set => overviewField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("responsibleOrganizationSelfAuthority")]
            public responsibleOrganizationSelfAuthoritySFType[] responsibleOrganizationSelfAuthority
            {
                get => responsibleOrganizationSelfAuthorityField;
                set => responsibleOrganizationSelfAuthorityField = value;
            }

            /// <remarks/>
            public responsibleOrganizationDelegateAuthoritySFType responsibleOrganizationDelegateAuthority
            {
                get => responsibleOrganizationDelegateAuthorityField;
                set => responsibleOrganizationDelegateAuthorityField = value;
            }

            /// <remarks/>
            public additionalDetailsType additionalDetails
            {
                get => additionalDetailsField;
                set => additionalDetailsField = value;
            }

            /// <remarks/>
            public approvedSFType approved
            {
                get => approvedField;
                set => approvedField = value;
            }

            /// <remarks/>
            public informingProcedureType informingProcedure
            {
                get => informingProcedureField;
                set => informingProcedureField = value;
            }

            /// <remarks/>
            public internetAddressesType internetAddresses
            {
                get => internetAddressesField;
                set => internetAddressesField = value;
            }

            /// <remarks/>
            public indicatorsSFType indicators
            {
                get => indicatorsField;
                set => indicatorsField = value;
            }

            /// <remarks/>
            [XmlArrayItemAttribute("roomRequirements", IsNullable = false)]
            public dictionarySFType[] roomSettings
            {
                get => roomSettingsField;
                set => roomSettingsField = value;
            }

            /// <remarks/>
            [XmlArrayItemAttribute("servicesInfo", IsNullable = false)]
            public servicesInfoType[] associatedServices
            {
                get => associatedServicesField;
                set => associatedServicesField = value;
            }

            /// <remarks/>
            public monitoringComplianceSFType monitoringCompliance
            {
                get => monitoringComplianceField;
                set => monitoringComplianceField = value;
            }

            /// <remarks/>
            public pretrialComplaintsProcedureSettingsSFType pretrialComplaintsProcedureSettings
            {
                get => pretrialComplaintsProcedureSettingsField;
                set => pretrialComplaintsProcedureSettingsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("subServices")]
            public subServicesSFType[] subServices
            {
                get => subServicesField;
                set => subServicesField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class templateAdmRegulationSettingNFType
        {

            private bool isStatementField;

            private bool isStatementFieldSpecified;

            private bool isHeaderField;

            private bool isHeaderFieldSpecified;

            private bool isDepartmentField;

            private bool isDepartmentFieldSpecified;

            private bool isPositionField;

            private bool isPositionFieldSpecified;

            private bool isFioField;

            private bool isFioFieldSpecified;

            /// <remarks/>
            public bool isStatement
            {
                get => isStatementField;
                set => isStatementField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isStatementSpecified
            {
                get => isStatementFieldSpecified;
                set => isStatementFieldSpecified = value;
            }

            /// <remarks/>
            public bool isHeader
            {
                get => isHeaderField;
                set => isHeaderField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isHeaderSpecified
            {
                get => isHeaderFieldSpecified;
                set => isHeaderFieldSpecified = value;
            }

            /// <remarks/>
            public bool isDepartment
            {
                get => isDepartmentField;
                set => isDepartmentField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isDepartmentSpecified
            {
                get => isDepartmentFieldSpecified;
                set => isDepartmentFieldSpecified = value;
            }

            /// <remarks/>
            public bool isPosition
            {
                get => isPositionField;
                set => isPositionField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isPositionSpecified
            {
                get => isPositionFieldSpecified;
                set => isPositionFieldSpecified = value;
            }

            /// <remarks/>
            public bool isFio
            {
                get => isFioField;
                set => isFioField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isFioSpecified
            {
                get => isFioFieldSpecified;
                set => isFioFieldSpecified = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class proactivityNFType
        {

            private bool hasproactivityField;

            private bool hasproactivityFieldSpecified;

            private bool isNeededStatementField;

            private bool isNeededStatementFieldSpecified;

            private dictionaryNFType[] additionalInformationIdsField;

            private dictionaryNFType[] infSystemSourceField;

            private dictionaryNFType[] infSystemTargetField;

            private dictionaryNFType proactivitySystemField;

            private dictionaryNFType[] proactivityTriggersField;

            /// <remarks/>
            public bool hasproactivity
            {
                get => hasproactivityField;
                set => hasproactivityField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool hasproactivitySpecified
            {
                get => hasproactivityFieldSpecified;
                set => hasproactivityFieldSpecified = value;
            }

            /// <remarks/>
            public bool isNeededStatement
            {
                get => isNeededStatementField;
                set => isNeededStatementField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isNeededStatementSpecified
            {
                get => isNeededStatementFieldSpecified;
                set => isNeededStatementFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("additionalInformationIds")]
            public dictionaryNFType[] additionalInformationIds
            {
                get => additionalInformationIdsField;
                set => additionalInformationIdsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("infSystemSource")]
            public dictionaryNFType[] infSystemSource
            {
                get => infSystemSourceField;
                set => infSystemSourceField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("infSystemTarget")]
            public dictionaryNFType[] infSystemTarget
            {
                get => infSystemTargetField;
                set => infSystemTargetField = value;
            }

            /// <remarks/>
            public dictionaryNFType proactivitySystem
            {
                get => proactivitySystemField;
                set => proactivitySystemField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("proactivityTriggers")]
            public dictionaryNFType[] proactivityTriggers
            {
                get => proactivityTriggersField;
                set => proactivityTriggersField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class proactiveNFType
        {

            private proactivityNFType proactivityField;

            private dictionaryNFType[] reasonsStartProactiveIdsField;

            private bool proactivityNonConfirmedField;

            private bool proactivityNonConfirmedFieldSpecified;

            private bool proactivityConfirmedField;

            private bool proactivityConfirmedFieldSpecified;

            /// <remarks/>
            public proactivityNFType proactivity
            {
                get => proactivityField;
                set => proactivityField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("reasonsStartProactiveIds")]
            public dictionaryNFType[] reasonsStartProactiveIds
            {
                get => reasonsStartProactiveIdsField;
                set => reasonsStartProactiveIdsField = value;
            }

            /// <remarks/>
            public bool proactivityNonConfirmed
            {
                get => proactivityNonConfirmedField;
                set => proactivityNonConfirmedField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool proactivityNonConfirmedSpecified
            {
                get => proactivityNonConfirmedFieldSpecified;
                set => proactivityNonConfirmedFieldSpecified = value;
            }

            /// <remarks/>
            public bool proactivityConfirmed
            {
                get => proactivityConfirmedField;
                set => proactivityConfirmedField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool proactivityConfirmedSpecified
            {
                get => proactivityConfirmedFieldSpecified;
                set => proactivityConfirmedFieldSpecified = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class administrativeActionsNFType
        {

            private dictionaryNFType nameField;

            private dictionaryNFType innerStatusField;

            private bool isAffectedByAdmActionField;

            private bool isAffectedByAdmActionFieldSpecified;

            private dictionaryNFType epguStatusField;

            private string epguStatusCommentField;

            private dictionaryNFType performedByField;

            private bool isAvailableInPgsField;

            private bool isAvailableInPgsFieldSpecified;

            private bool isSuspensionServiceField;

            private bool isSuspensionServiceFieldSpecified;

            private string timeFrameQuantityField;

            private dictionaryNFType timeFrameUnitField;

            private bool isServiceTimeFrameAffectedField;

            private bool isServiceTimeFrameAffectedFieldSpecified;

            private string timeMvzQuantityField;

            private dictionaryNFType timeMvzUnitField;

            private dictionaryNFType[] reasonsAdditionalInformationField;

            private dictionaryNFType[] authoritiesField;

            private string[] additionalInformationInField;

            private string[] additionalInformationOutField;

            private string[] documentsInField;

            private string[] documentsOutField;

            /// <remarks/>
            public dictionaryNFType name
            {
                get => nameField;
                set => nameField = value;
            }

            /// <remarks/>
            public dictionaryNFType innerStatus
            {
                get => innerStatusField;
                set => innerStatusField = value;
            }

            /// <remarks/>
            public bool isAffectedByAdmAction
            {
                get => isAffectedByAdmActionField;
                set => isAffectedByAdmActionField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isAffectedByAdmActionSpecified
            {
                get => isAffectedByAdmActionFieldSpecified;
                set => isAffectedByAdmActionFieldSpecified = value;
            }

            /// <remarks/>
            public dictionaryNFType epguStatus
            {
                get => epguStatusField;
                set => epguStatusField = value;
            }

            /// <remarks/>
            public string epguStatusComment
            {
                get => epguStatusCommentField;
                set => epguStatusCommentField = value;
            }

            /// <remarks/>
            public dictionaryNFType performedBy
            {
                get => performedByField;
                set => performedByField = value;
            }

            /// <remarks/>
            public bool isAvailableInPgs
            {
                get => isAvailableInPgsField;
                set => isAvailableInPgsField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isAvailableInPgsSpecified
            {
                get => isAvailableInPgsFieldSpecified;
                set => isAvailableInPgsFieldSpecified = value;
            }

            /// <remarks/>
            public bool isSuspensionService
            {
                get => isSuspensionServiceField;
                set => isSuspensionServiceField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isSuspensionServiceSpecified
            {
                get => isSuspensionServiceFieldSpecified;
                set => isSuspensionServiceFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string timeFrameQuantity
            {
                get => timeFrameQuantityField;
                set => timeFrameQuantityField = value;
            }

            /// <remarks/>
            public dictionaryNFType timeFrameUnit
            {
                get => timeFrameUnitField;
                set => timeFrameUnitField = value;
            }

            /// <remarks/>
            public bool isServiceTimeFrameAffected
            {
                get => isServiceTimeFrameAffectedField;
                set => isServiceTimeFrameAffectedField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isServiceTimeFrameAffectedSpecified
            {
                get => isServiceTimeFrameAffectedFieldSpecified;
                set => isServiceTimeFrameAffectedFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string timeMvzQuantity
            {
                get => timeMvzQuantityField;
                set => timeMvzQuantityField = value;
            }

            /// <remarks/>
            public dictionaryNFType timeMvzUnit
            {
                get => timeMvzUnitField;
                set => timeMvzUnitField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("reasonsAdditionalInformation")]
            public dictionaryNFType[] reasonsAdditionalInformation
            {
                get => reasonsAdditionalInformationField;
                set => reasonsAdditionalInformationField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("authorities")]
            public dictionaryNFType[] authorities
            {
                get => authoritiesField;
                set => authoritiesField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("additionalInformationIn")]
            public string[] additionalInformationIn
            {
                get => additionalInformationInField;
                set => additionalInformationInField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("additionalInformationOut")]
            public string[] additionalInformationOut
            {
                get => additionalInformationOutField;
                set => additionalInformationOutField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("documentsIn")]
            public string[] documentsIn
            {
                get => documentsInField;
                set => documentsInField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("documentsOut")]
            public string[] documentsOut
            {
                get => documentsOutField;
                set => documentsOutField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class administrativeProceduresNFType
        {

            private string orderField;

            private string numberField;

            private dictionaryNFType nameField;

            private string timeFrameQuantityField;

            private dictionaryNFType timeFrameUnitField;

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string order
            {
                get => orderField;
                set => orderField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string number
            {
                get => numberField;
                set => numberField = value;
            }

            /// <remarks/>
            public dictionaryNFType name
            {
                get => nameField;
                set => nameField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string timeFrameQuantity
            {
                get => timeFrameQuantityField;
                set => timeFrameQuantityField = value;
            }

            /// <remarks/>
            public dictionaryNFType timeFrameUnit
            {
                get => timeFrameUnitField;
                set => timeFrameUnitField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class administrativeProceduresActionsNFType
        {

            private administrativeProceduresNFType[] administrativeProceduresField;

            private administrativeActionsNFType[] administrativeActionsField;

            /// <remarks/>
            [XmlElementAttribute("administrativeProcedures")]
            public administrativeProceduresNFType[] administrativeProcedures
            {
                get => administrativeProceduresField;
                set => administrativeProceduresField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("administrativeActions")]
            public administrativeActionsNFType[] administrativeActions
            {
                get => administrativeActionsField;
                set => administrativeActionsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class profilingAnswerProcedureNFType
        {

            private dictionaryNFType admProcedureNameField;

            private string timeFrameQuantityField;

            private dictionaryNFType timeFrameUnitField;

            private string numberField;

            /// <remarks/>
            public dictionaryNFType admProcedureName
            {
                get => admProcedureNameField;
                set => admProcedureNameField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string timeFrameQuantity
            {
                get => timeFrameQuantityField;
                set => timeFrameQuantityField = value;
            }

            /// <remarks/>
            public dictionaryNFType timeFrameUnit
            {
                get => timeFrameUnitField;
                set => timeFrameUnitField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string number
            {
                get => numberField;
                set => numberField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class paymentsNFType
        {

            private bool payableField;

            private bool payableFieldSpecified;

            /// <remarks/>
            public bool payable
            {
                get => payableField;
                set => payableField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool payableSpecified
            {
                get => payableFieldSpecified;
                set => payableFieldSpecified = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class documentsDNFType
        {

            private dictionaryNFType documentField;

            private admProceduresNFType[] admProceduresField;

            private attributeSettingsNFType[] attributeSettingsField;

            private criteriaNFType[] criteriaField;

            /// <remarks/>
            public dictionaryNFType document
            {
                get => documentField;
                set => documentField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("admProcedures")]
            public admProceduresNFType[] admProcedures
            {
                get => admProceduresField;
                set => admProceduresField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeSettings")]
            public attributeSettingsNFType[] attributeSettings
            {
                get => attributeSettingsField;
                set => attributeSettingsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("criteria")]
            public criteriaNFType[] criteria
            {
                get => criteriaField;
                set => criteriaField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class admProceduresNFType
        {

            private dictionaryNFType admProcedureField;

            private string deadlineField;

            private dictionaryNFType unitsOfMeasurementField;

            /// <remarks/>
            public dictionaryNFType admProcedure
            {
                get => admProcedureField;
                set => admProcedureField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string deadline
            {
                get => deadlineField;
                set => deadlineField = value;
            }

            /// <remarks/>
            public dictionaryNFType unitsOfMeasurement
            {
                get => unitsOfMeasurementField;
                set => unitsOfMeasurementField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class attributeSettingsNFType
        {

            private dictionaryNFType attributeField;

            /// <remarks/>
            public dictionaryNFType attribute
            {
                get => attributeField;
                set => attributeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class criteriaNFType
        {

            private dictionaryCriterionType criterionField;

            private dictionaryNFType decisionTypeField;

            private dictionaryNFType rejectionReasonField;

            private dictionaryNFType[] documentRequirementsField;

            /// <remarks/>
            public dictionaryCriterionType criterion
            {
                get => criterionField;
                set => criterionField = value;
            }

            /// <remarks/>
            public dictionaryNFType decisionType
            {
                get => decisionTypeField;
                set => decisionTypeField = value;
            }

            /// <remarks/>
            public dictionaryNFType rejectionReason
            {
                get => rejectionReasonField;
                set => rejectionReasonField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("documentRequirements")]
            public dictionaryNFType[] documentRequirements
            {
                get => documentRequirementsField;
                set => documentRequirementsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class dictionaryCriterionType
        {

            private string nameField;

            private string negativeMeaningField;

            /// <remarks/>
            public string name
            {
                get => nameField;
                set => nameField = value;
            }

            /// <remarks/>
            public string negativeMeaning
            {
                get => negativeMeaningField;
                set => negativeMeaningField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class documentsCategoryNFType
        {

            private dictionaryNFType documentCategoryField;

            private bool isAnyCategoryField;

            private bool isAnyCategoryFieldSpecified;

            private documentsDNFType[] documentsField;

            /// <remarks/>
            public dictionaryNFType documentCategory
            {
                get => documentCategoryField;
                set => documentCategoryField = value;
            }

            /// <remarks/>
            public bool isAnyCategory
            {
                get => isAnyCategoryField;
                set => isAnyCategoryField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isAnyCategorySpecified
            {
                get => isAnyCategoryFieldSpecified;
                set => isAnyCategoryFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("documents")]
            public documentsDNFType[] documents
            {
                get => documentsField;
                set => documentsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class requestsNoSmevNFType
        {

            private request3NFType requestField;

            private dictionaryNFType reasonServiceField;

            private string timeRequestField;

            private dictionaryNFType timeRequestMeasureField;

            private string timeResponseField;

            private dictionaryNFType timeResponseMeasureField;

            private criteriaNFType[] criteriaField;

            private admProceduresNFType[] admProceduresField;

            private attributeRequestsNFType[] attributeRequestsField;

            private attributeResponsesNFType[] attributeResponsesField;

            /// <remarks/>
            public request3NFType request
            {
                get => requestField;
                set => requestField = value;
            }

            /// <remarks/>
            public dictionaryNFType reasonService
            {
                get => reasonServiceField;
                set => reasonServiceField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string timeRequest
            {
                get => timeRequestField;
                set => timeRequestField = value;
            }

            /// <remarks/>
            public dictionaryNFType timeRequestMeasure
            {
                get => timeRequestMeasureField;
                set => timeRequestMeasureField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string timeResponse
            {
                get => timeResponseField;
                set => timeResponseField = value;
            }

            /// <remarks/>
            public dictionaryNFType timeResponseMeasure
            {
                get => timeResponseMeasureField;
                set => timeResponseMeasureField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("criteria")]
            public criteriaNFType[] criteria
            {
                get => criteriaField;
                set => criteriaField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("admProcedures")]
            public admProceduresNFType[] admProcedures
            {
                get => admProceduresField;
                set => admProceduresField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeRequests")]
            public attributeRequestsNFType[] attributeRequests
            {
                get => attributeRequestsField;
                set => attributeRequestsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeResponses")]
            public attributeResponsesNFType[] attributeResponses
            {
                get => attributeResponsesField;
                set => attributeResponsesField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class request3NFType
        {

            private string nameField;

            private dictionaryNFType ownerServiceField;

            /// <remarks/>
            public string name
            {
                get => nameField;
                set => nameField = value;
            }

            /// <remarks/>
            public dictionaryNFType ownerService
            {
                get => ownerServiceField;
                set => ownerServiceField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class attributeRequestsNFType
        {

            private dictionaryNFType attributeField;

            private bool isDecisionMakingField;

            private bool isDecisionMakingFieldSpecified;

            private bool isRegistryEntryField;

            private bool isRegistryEntryFieldSpecified;

            private bool isAssessmentProcedureField;

            private bool isAssessmentProcedureFieldSpecified;

            private bool isInterdepartmentalInteractionField;

            private bool isInterdepartmentalInteractionFieldSpecified;

            private bool isInteractionWithApplicantField;

            private bool isInteractionWithApplicantFieldSpecified;

            /// <remarks/>
            public dictionaryNFType attribute
            {
                get => attributeField;
                set => attributeField = value;
            }

            /// <remarks/>
            public bool isDecisionMaking
            {
                get => isDecisionMakingField;
                set => isDecisionMakingField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isDecisionMakingSpecified
            {
                get => isDecisionMakingFieldSpecified;
                set => isDecisionMakingFieldSpecified = value;
            }

            /// <remarks/>
            public bool isRegistryEntry
            {
                get => isRegistryEntryField;
                set => isRegistryEntryField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isRegistryEntrySpecified
            {
                get => isRegistryEntryFieldSpecified;
                set => isRegistryEntryFieldSpecified = value;
            }

            /// <remarks/>
            public bool isAssessmentProcedure
            {
                get => isAssessmentProcedureField;
                set => isAssessmentProcedureField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isAssessmentProcedureSpecified
            {
                get => isAssessmentProcedureFieldSpecified;
                set => isAssessmentProcedureFieldSpecified = value;
            }

            /// <remarks/>
            public bool isInterdepartmentalInteraction
            {
                get => isInterdepartmentalInteractionField;
                set => isInterdepartmentalInteractionField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isInterdepartmentalInteractionSpecified
            {
                get => isInterdepartmentalInteractionFieldSpecified;
                set => isInterdepartmentalInteractionFieldSpecified = value;
            }

            /// <remarks/>
            public bool isInteractionWithApplicant
            {
                get => isInteractionWithApplicantField;
                set => isInteractionWithApplicantField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isInteractionWithApplicantSpecified
            {
                get => isInteractionWithApplicantFieldSpecified;
                set => isInteractionWithApplicantFieldSpecified = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class attributeResponsesNFType
        {

            private dictionaryNFType attributeField;

            /// <remarks/>
            public dictionaryNFType attribute
            {
                get => attributeField;
                set => attributeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class requests3NFType
        {

            private request3NFType requestField;

            private dictionaryNFType reasonServiceField;

            private string timeRequestField;

            private dictionaryNFType timeRequestMeasureField;

            private string timeResponseField;

            private dictionaryNFType timeResponseMeasureField;

            private criteriaNFType[] criteriaField;

            private admProceduresNFType[] admProceduresField;

            private attributeRequestsNFType[] attributeRequestsField;

            private attributeResponsesNFType[] attributeResponsesField;

            /// <remarks/>
            public request3NFType request
            {
                get => requestField;
                set => requestField = value;
            }

            /// <remarks/>
            public dictionaryNFType reasonService
            {
                get => reasonServiceField;
                set => reasonServiceField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string timeRequest
            {
                get => timeRequestField;
                set => timeRequestField = value;
            }

            /// <remarks/>
            public dictionaryNFType timeRequestMeasure
            {
                get => timeRequestMeasureField;
                set => timeRequestMeasureField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string timeResponse
            {
                get => timeResponseField;
                set => timeResponseField = value;
            }

            /// <remarks/>
            public dictionaryNFType timeResponseMeasure
            {
                get => timeResponseMeasureField;
                set => timeResponseMeasureField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("criteria")]
            public criteriaNFType[] criteria
            {
                get => criteriaField;
                set => criteriaField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("admProcedures")]
            public admProceduresNFType[] admProcedures
            {
                get => admProceduresField;
                set => admProceduresField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeRequests")]
            public attributeRequestsNFType[] attributeRequests
            {
                get => attributeRequestsField;
                set => attributeRequestsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeResponses")]
            public attributeResponsesNFType[] attributeResponses
            {
                get => attributeResponsesField;
                set => attributeResponsesField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class requestsNFType
        {

            private dictionaryNFType requestField;

            private dictionaryNFType reasonServiceField;

            private string timeRequestField;

            private dictionaryNFType timeRequestMeasureField;

            private string timeResponseField;

            private dictionaryNFType timeResponseMeasureField;

            private criteriaNFType[] criteriaField;

            private admProceduresNFType[] admProceduresField;

            private attributeRequestsNFType[] attributeRequestsField;

            private attributeResponsesNFType[] attributeResponsesField;

            /// <remarks/>
            public dictionaryNFType request
            {
                get => requestField;
                set => requestField = value;
            }

            /// <remarks/>
            public dictionaryNFType reasonService
            {
                get => reasonServiceField;
                set => reasonServiceField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string timeRequest
            {
                get => timeRequestField;
                set => timeRequestField = value;
            }

            /// <remarks/>
            public dictionaryNFType timeRequestMeasure
            {
                get => timeRequestMeasureField;
                set => timeRequestMeasureField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string timeResponse
            {
                get => timeResponseField;
                set => timeResponseField = value;
            }

            /// <remarks/>
            public dictionaryNFType timeResponseMeasure
            {
                get => timeResponseMeasureField;
                set => timeResponseMeasureField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("criteria")]
            public criteriaNFType[] criteria
            {
                get => criteriaField;
                set => criteriaField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("admProcedures")]
            public admProceduresNFType[] admProcedures
            {
                get => admProceduresField;
                set => admProceduresField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeRequests")]
            public attributeRequestsNFType[] attributeRequests
            {
                get => attributeRequestsField;
                set => attributeRequestsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeResponses")]
            public attributeResponsesNFType[] attributeResponses
            {
                get => attributeResponsesField;
                set => attributeResponsesField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class serviceNFType
        {

            private dictionaryNFType ownerServiceField;

            /// <remarks/>
            public dictionaryNFType ownerService
            {
                get => ownerServiceField;
                set => ownerServiceField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class smevServiceNFType
        {

            private serviceNFType serviceField;

            private requestsNFType[] requestsField;

            /// <remarks/>
            public serviceNFType service
            {
                get => serviceField;
                set => serviceField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("requests")]
            public requestsNFType[] requests
            {
                get => requestsField;
                set => requestsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class smev2NFType
        {

            private smevServiceNFType smevServiceField;

            /// <remarks/>
            public smevServiceNFType smevService
            {
                get => smevServiceField;
                set => smevServiceField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class interdepartmentalRequestNFType
        {

            private smev2NFType[] smev2Field;

            // private requests3NFType[][] smev3Field;
            private object3Type[] smev3Field;

            // private requestsNoSmevNFType[][] noSmevField;
            private object5Type[] noSmevField;

            /// <remarks/>
            [XmlElementAttribute("smev2")]
            public smev2NFType[] smev2
            {
                get => smev2Field;
                set => smev2Field = value;
            }

            /// <remarks/>
            //[XmlArrayItemAttribute("requests", typeof(requests3NFType), IsNullable = false)]
            [XmlElement("smev3")]
            public object3Type[] smev3
            {
                get => smev3Field;
                set => smev3Field = value;
            }

            /// <remarks/>
            //[XmlArrayItemAttribute("requests", typeof(requestsNoSmevNFType), IsNullable = false)]
            [XmlElement("noSmev")]
            public object5Type[] noSmev
            {
                get => noSmevField;
                set => noSmevField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class additionalInformationsNFType
        {

            private dictionaryNFType infoTypeField;

            private admProceduresNFType[] admProceduresField;

            private attributeSettingsNFType[] attributeSettingsField;

            private criteriaNFType[] criteriaField;

            /// <remarks/>
            public dictionaryNFType infoType
            {
                get => infoTypeField;
                set => infoTypeField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("admProcedures")]
            public admProceduresNFType[] admProcedures
            {
                get => admProceduresField;
                set => admProceduresField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("attributeSettings")]
            public attributeSettingsNFType[] attributeSettings
            {
                get => attributeSettingsField;
                set => attributeSettingsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("criteria")]
            public criteriaNFType[] criteria
            {
                get => criteriaField;
                set => criteriaField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class answersNFType
        {

            private string answerСontainerIdField;

            private string idField;

            private string userAnswerNameField;

            private bool isTypicalField;

            private bool isTypicalFieldSpecified;

            private dictionaryNFType typicalAnswerField;

            private bool isPossibleMultipleAnswerField;

            private bool isPossibleMultipleAnswerFieldSpecified;

            private bool isProactiveField;

            private bool isProactiveFieldSpecified;

            private additionalInformationsNFType[] additionalInformationsField;

            private interdepartmentalRequestNFType interdepartmentalRequestField;

            //private documentsCategoryNFType[][] documentsField;
            private documentsCategoryNFType[] documentsField;

            private paymentsNFType paymentsField;

            private profilingAnswerProcedureNFType[] profilingAnswerProcedureField;

            /// <remarks/>
            public string answerСontainerId
            {
                get => answerСontainerIdField;
                set => answerСontainerIdField = value;
            }

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string userAnswerName
            {
                get => userAnswerNameField;
                set => userAnswerNameField = value;
            }

            /// <remarks/>
            public bool isTypical
            {
                get => isTypicalField;
                set => isTypicalField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isTypicalSpecified
            {
                get => isTypicalFieldSpecified;
                set => isTypicalFieldSpecified = value;
            }

            /// <remarks/>
            public dictionaryNFType typicalAnswer
            {
                get => typicalAnswerField;
                set => typicalAnswerField = value;
            }

            /// <remarks/>
            public bool isPossibleMultipleAnswer
            {
                get => isPossibleMultipleAnswerField;
                set => isPossibleMultipleAnswerField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isPossibleMultipleAnswerSpecified
            {
                get => isPossibleMultipleAnswerFieldSpecified;
                set => isPossibleMultipleAnswerFieldSpecified = value;
            }

            /// <remarks/>
            public bool isProactive
            {
                get => isProactiveField;
                set => isProactiveField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isProactiveSpecified
            {
                get => isProactiveFieldSpecified;
                set => isProactiveFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("additionalInformations")]
            public additionalInformationsNFType[] additionalInformations
            {
                get => additionalInformationsField;
                set => additionalInformationsField = value;
            }

            /// <remarks/>
            public interdepartmentalRequestNFType interdepartmentalRequest
            {
                get => interdepartmentalRequestField;
                set => interdepartmentalRequestField = value;
            }

            /// <remarks/>
            [XmlArrayItemAttribute("documentsCategory", typeof(documentsCategoryNFType), IsNullable = false)]
            //[XmlElementAttribute("documents")]
            public documentsCategoryNFType[] documents
            {
                get => documentsField;
                set => documentsField = value;
            }

            /// <remarks/>
            public paymentsNFType payments
            {
                get => paymentsField;
                set => paymentsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("profilingAnswerProcedure")]
            public profilingAnswerProcedureNFType[] profilingAnswerProcedure
            {
                get => profilingAnswerProcedureField;
                set => profilingAnswerProcedureField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class questionsNFType
        {

            private string idField;

            private string questionСontainerIdField;

            private string userQuestionField;

            private bool isTypicalField;

            private bool isTypicalFieldSpecified;

            private dictionaryNFType typicalQuestionField;

            private bool isPossibleMultipleAnswerField;

            private bool isPossibleMultipleAnswerFieldSpecified;

            /// <remarks/>
            public string id
            {
                get => idField;
                set => idField = value;
            }

            /// <remarks/>
            public string questionСontainerId
            {
                get => questionСontainerIdField;
                set => questionСontainerIdField = value;
            }

            /// <remarks/>
            public string userQuestion
            {
                get => userQuestionField;
                set => userQuestionField = value;
            }

            /// <remarks/>
            public bool isTypical
            {
                get => isTypicalField;
                set => isTypicalField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isTypicalSpecified
            {
                get => isTypicalFieldSpecified;
                set => isTypicalFieldSpecified = value;
            }

            /// <remarks/>
            public dictionaryNFType typicalQuestion
            {
                get => typicalQuestionField;
                set => typicalQuestionField = value;
            }

            /// <remarks/>
            public bool isPossibleMultipleAnswer
            {
                get => isPossibleMultipleAnswerField;
                set => isPossibleMultipleAnswerField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isPossibleMultipleAnswerSpecified
            {
                get => isPossibleMultipleAnswerFieldSpecified;
                set => isPossibleMultipleAnswerFieldSpecified = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class profilingSettingsNFType
        {

            private questionsNFType[] questionsField;

            private answersNFType[] answersField;

            /// <remarks/>
            [XmlElementAttribute("questions")]
            public questionsNFType[] questions
            {
                get => questionsField;
                set => questionsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("answers")]
            public answersNFType[] answers
            {
                get => answersField;
                set => answersField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class expertProcedureResultsNFType
        {

            private dictionaryNFType procedureResultField;

            private bool isDecisionMakingField;

            private bool isDecisionMakingFieldSpecified;

            private bool isRegistryEntryField;

            private bool isRegistryEntryFieldSpecified;

            private bool isInteractionWithApplicantField;

            private bool isInteractionWithApplicantFieldSpecified;

            private bool isRequiredField;

            private bool isRequiredFieldSpecified;

            private string nameISProcedureResultField;

            private DateTime dateProcedureResultField;

            private bool dateProcedureResultFieldSpecified;

            /// <remarks/>
            public dictionaryNFType ProcedureResult
            {
                get => procedureResultField;
                set => procedureResultField = value;
            }

            /// <remarks/>
            public bool isDecisionMaking
            {
                get => isDecisionMakingField;
                set => isDecisionMakingField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isDecisionMakingSpecified
            {
                get => isDecisionMakingFieldSpecified;
                set => isDecisionMakingFieldSpecified = value;
            }

            /// <remarks/>
            public bool isRegistryEntry
            {
                get => isRegistryEntryField;
                set => isRegistryEntryField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isRegistryEntrySpecified
            {
                get => isRegistryEntryFieldSpecified;
                set => isRegistryEntryFieldSpecified = value;
            }

            /// <remarks/>
            public bool isInteractionWithApplicant
            {
                get => isInteractionWithApplicantField;
                set => isInteractionWithApplicantField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isInteractionWithApplicantSpecified
            {
                get => isInteractionWithApplicantFieldSpecified;
                set => isInteractionWithApplicantFieldSpecified = value;
            }

            /// <remarks/>
            public bool isRequired
            {
                get => isRequiredField;
                set => isRequiredField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isRequiredSpecified
            {
                get => isRequiredFieldSpecified;
                set => isRequiredFieldSpecified = value;
            }

            /// <remarks/>
            public string nameISProcedureResult
            {
                get => nameISProcedureResultField;
                set => nameISProcedureResultField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "date")]
            public DateTime dateProcedureResult
            {
                get => dateProcedureResultField;
                set => dateProcedureResultField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool dateProcedureResultSpecified
            {
                get => dateProcedureResultFieldSpecified;
                set => dateProcedureResultFieldSpecified = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class expertProcedureSettingsNFType
        {

            private dictionaryNFType expertProcedureTypeField;

            private dictionaryNFType[] expertProcedurePurposeField;

            private dictionaryNFType[] expertProcedureObjectField;

            private string expertProcedureDurationField;

            private dictionaryNFType expertProcedureDurationUnitField;

            private dictionaryFullNameNFType[] expertProcedureOrganizationsField;

            private dictionaryFullNameNFType[] expertProcedureMinorOrganizationsField;

            private expertProcedureResultsNFType[] expertProcedureResultsField;

            /// <remarks/>
            public dictionaryNFType expertProcedureType
            {
                get => expertProcedureTypeField;
                set => expertProcedureTypeField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedurePurpose")]
            public dictionaryNFType[] expertProcedurePurpose
            {
                get => expertProcedurePurposeField;
                set => expertProcedurePurposeField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedureObject")]
            public dictionaryNFType[] expertProcedureObject
            {
                get => expertProcedureObjectField;
                set => expertProcedureObjectField = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string expertProcedureDuration
            {
                get => expertProcedureDurationField;
                set => expertProcedureDurationField = value;
            }

            /// <remarks/>
            public dictionaryNFType expertProcedureDurationUnit
            {
                get => expertProcedureDurationUnitField;
                set => expertProcedureDurationUnitField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedureOrganizations")]
            public dictionaryFullNameNFType[] expertProcedureOrganizations
            {
                get => expertProcedureOrganizationsField;
                set => expertProcedureOrganizationsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedureMinorOrganizations")]
            public dictionaryFullNameNFType[] expertProcedureMinorOrganizations
            {
                get => expertProcedureMinorOrganizationsField;
                set => expertProcedureMinorOrganizationsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedureResults")]
            public expertProcedureResultsNFType[] expertProcedureResults
            {
                get => expertProcedureResultsField;
                set => expertProcedureResultsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class dictionaryFullNameNFType
        {

            private string fullNameField;

            /// <remarks/>
            public string fullName
            {
                get => fullNameField;
                set => fullNameField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class expertProcedureNFType
        {

            private bool hasExpertProcedurePlannedField;

            private bool hasExpertProcedurePlannedFieldSpecified;

            private expertProcedureSettingsNFType[] expertProcedureSettingsField;

            /// <remarks/>
            public bool hasExpertProcedurePlanned
            {
                get => hasExpertProcedurePlannedField;
                set => hasExpertProcedurePlannedField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool hasExpertProcedurePlannedSpecified
            {
                get => hasExpertProcedurePlannedFieldSpecified;
                set => hasExpertProcedurePlannedFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("expertProcedureSettings")]
            public expertProcedureSettingsNFType[] expertProcedureSettings
            {
                get => expertProcedureSettingsField;
                set => expertProcedureSettingsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class resourceConstraintNFType
        {

            private bool[] hasResourceConstraintField;

            private dictionaryNFType constraintField;

            private dictionaryNFType resourceConstraintObjectIdField;

            /// <remarks/>
            [XmlElementAttribute("hasResourceConstraint")]
            public bool[] hasResourceConstraint
            {
                get => hasResourceConstraintField;
                set => hasResourceConstraintField = value;
            }

            /// <remarks/>
            public dictionaryNFType Constraint
            {
                get => constraintField;
                set => constraintField = value;
            }

            /// <remarks/>
            public dictionaryNFType resourceConstraintObjectId
            {
                get => resourceConstraintObjectIdField;
                set => resourceConstraintObjectIdField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class resultDocumentSettingsNFType
        {

            private dictionaryNFType resultDocumentField;

            private dictionaryNFType[] resultDocumentFormsField;

            /// <remarks/>
            public dictionaryNFType resultDocument
            {
                get => resultDocumentField;
                set => resultDocumentField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultDocumentForms")]
            public dictionaryNFType[] resultDocumentForms
            {
                get => resultDocumentFormsField;
                set => resultDocumentFormsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class resultsInfoNFType
        {

            private dictionaryNFType resultNameField;

            private resultDocumentSettingsNFType[] resultDocumentSettingsField;

            private dictionaryNFType[] resultObjectsField;

            private string resultSolutionNameField;

            private dictionaryNFType[] resultSolutionAttributesField;

            private dictionaryNFType resultRegistryField;

            private dictionaryNFType[] resultRegistryAttributesField;

            private dictionaryNFType resultSystemField;

            private dictionaryNFType resultRegistryActionField;

            private dictionaryNFType[] resultChannelsField;

            /// <remarks/>
            public dictionaryNFType resultName
            {
                get => resultNameField;
                set => resultNameField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultDocumentSettings")]
            public resultDocumentSettingsNFType[] resultDocumentSettings
            {
                get => resultDocumentSettingsField;
                set => resultDocumentSettingsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultObjects")]
            public dictionaryNFType[] resultObjects
            {
                get => resultObjectsField;
                set => resultObjectsField = value;
            }

            /// <remarks/>
            public string resultSolutionName
            {
                get => resultSolutionNameField;
                set => resultSolutionNameField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultSolutionAttributes")]
            public dictionaryNFType[] resultSolutionAttributes
            {
                get => resultSolutionAttributesField;
                set => resultSolutionAttributesField = value;
            }

            /// <remarks/>
            public dictionaryNFType resultRegistry
            {
                get => resultRegistryField;
                set => resultRegistryField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultRegistryAttributes")]
            public dictionaryNFType[] resultRegistryAttributes
            {
                get => resultRegistryAttributesField;
                set => resultRegistryAttributesField = value;
            }

            /// <remarks/>
            public dictionaryNFType resultSystem
            {
                get => resultSystemField;
                set => resultSystemField = value;
            }

            /// <remarks/>
            public dictionaryNFType resultRegistryAction
            {
                get => resultRegistryActionField;
                set => resultRegistryActionField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultChannels")]
            public dictionaryNFType[] resultChannels
            {
                get => resultChannelsField;
                set => resultChannelsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class resultsNFType
        {

            private dictionaryNFType resultAmountField;

            private bool hasDifferentRuleField;

            private bool hasDifferentRuleFieldSpecified;

            private resultsInfoNFType[] resultsInfoField;

            /// <remarks/>
            public dictionaryNFType resultAmount
            {
                get => resultAmountField;
                set => resultAmountField = value;
            }

            /// <remarks/>
            public bool hasDifferentRule
            {
                get => hasDifferentRuleField;
                set => hasDifferentRuleField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool hasDifferentRuleSpecified
            {
                get => hasDifferentRuleFieldSpecified;
                set => hasDifferentRuleFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultsInfo")]
            public resultsInfoNFType[] resultsInfo
            {
                get => resultsInfoField;
                set => resultsInfoField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class periodRegistrationNFType
        {

            private bool isMaxTimeFixedField;

            private bool isMaxTimeFixedFieldSpecified;

            private bool isOnlineField;

            private bool isOnlineFieldSpecified;

            private string maxPeriodOfProvidingField;

            private dictionaryNFType maxPeriodOfProvidingMeasureField;

            private string maxPeriodOfProvidingCommentField;

            /// <remarks/>
            public bool isMaxTimeFixed
            {
                get => isMaxTimeFixedField;
                set => isMaxTimeFixedField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isMaxTimeFixedSpecified
            {
                get => isMaxTimeFixedFieldSpecified;
                set => isMaxTimeFixedFieldSpecified = value;
            }

            /// <remarks/>
            public bool isOnline
            {
                get => isOnlineField;
                set => isOnlineField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isOnlineSpecified
            {
                get => isOnlineFieldSpecified;
                set => isOnlineFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string maxPeriodOfProviding
            {
                get => maxPeriodOfProvidingField;
                set => maxPeriodOfProvidingField = value;
            }

            /// <remarks/>
            public dictionaryNFType maxPeriodOfProvidingMeasure
            {
                get => maxPeriodOfProvidingMeasureField;
                set => maxPeriodOfProvidingMeasureField = value;
            }

            /// <remarks/>
            public string maxPeriodOfProvidingComment
            {
                get => maxPeriodOfProvidingCommentField;
                set => maxPeriodOfProvidingCommentField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class resultChannelsNFType
        {

            private dictionaryNFType channelField;

            private string extraterritorialityTypeField;

            /// <remarks/>
            public dictionaryNFType channel
            {
                get => channelField;
                set => channelField = value;
            }

            /// <remarks/>
            public string extraterritorialityType
            {
                get => extraterritorialityTypeField;
                set => extraterritorialityTypeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class requestChannelsNFType
        {

            private dictionaryNFType channelField;

            private string extraterritorialityTypeField;

            private dictionaryNFType[] identifyMethodsField;

            private dictionaryNFType[] applicantsField;

            /// <remarks/>
            public dictionaryNFType channel
            {
                get => channelField;
                set => channelField = value;
            }

            /// <remarks/>
            public string extraterritorialityType
            {
                get => extraterritorialityTypeField;
                set => extraterritorialityTypeField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("identifyMethods")]
            public dictionaryNFType[] identifyMethods
            {
                get => identifyMethodsField;
                set => identifyMethodsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("applicants")]
            public dictionaryNFType[] applicants
            {
                get => applicantsField;
                set => applicantsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class channelsNFType
        {

            private requestChannelsNFType[] requestChannelsField;

            private resultChannelsNFType[] resultChannelsField;

            /// <remarks/>
            [XmlElementAttribute("requestChannels")]
            public requestChannelsNFType[] requestChannels
            {
                get => requestChannelsField;
                set => requestChannelsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("resultChannels")]
            public resultChannelsNFType[] resultChannels
            {
                get => resultChannelsField;
                set => resultChannelsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class applicantCategoriesNFType
        {

            private dictionaryNFType applicantField;

            private bool agentableField;

            private bool agentableFieldSpecified;

            private dictionaryNFType[] agentTypesField;

            /// <remarks/>
            public dictionaryNFType applicant
            {
                get => applicantField;
                set => applicantField = value;
            }

            /// <remarks/>
            public bool agentable
            {
                get => agentableField;
                set => agentableField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool agentableSpecified
            {
                get => agentableFieldSpecified;
                set => agentableFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("agentTypes")]
            public dictionaryNFType[] agentTypes
            {
                get => agentTypesField;
                set => agentTypesField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class overviewSubServicesNFType
        {

            private string fullNameField;

            /// <remarks/>
            public string fullName
            {
                get => fullNameField;
                set => fullNameField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class subServicesNFType
        {

            private overviewSubServicesNFType overviewField;

            private applicantCategoriesNFType[] applicantCategoriesField;

            private channelsNFType channelsField;

            private periodRegistrationNFType periodRegistrationField;

            private resultsNFType resultsField;

            private resourceConstraintNFType resourceConstraintField;

            private expertProcedureNFType expertProcedureField;

            private profilingSettingsNFType[] profilingField;

            private administrativeProceduresActionsNFType administrativeProceduresActionsField;

            private proactiveNFType proactiveField;

            /// <remarks/>
            public overviewSubServicesNFType overview
            {
                get => overviewField;
                set => overviewField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("applicantCategories")]
            public applicantCategoriesNFType[] applicantCategories
            {
                get => applicantCategoriesField;
                set => applicantCategoriesField = value;
            }

            /// <remarks/>
            public channelsNFType channels
            {
                get => channelsField;
                set => channelsField = value;
            }

            /// <remarks/>
            public periodRegistrationNFType periodRegistration
            {
                get => periodRegistrationField;
                set => periodRegistrationField = value;
            }

            /// <remarks/>
            public resultsNFType results
            {
                get => resultsField;
                set => resultsField = value;
            }

            /// <remarks/>
            public resourceConstraintNFType resourceConstraint
            {
                get => resourceConstraintField;
                set => resourceConstraintField = value;
            }

            /// <remarks/>
            public expertProcedureNFType expertProcedure
            {
                get => expertProcedureField;
                set => expertProcedureField = value;
            }

            /// <remarks/>
            [XmlArrayItemAttribute("profilingSettings", IsNullable = false)]
            public profilingSettingsNFType[] profiling
            {
                get => profilingField;
                set => profilingField = value;
            }

            /// <remarks/>
            public administrativeProceduresActionsNFType administrativeProceduresActions
            {
                get => administrativeProceduresActionsField;
                set => administrativeProceduresActionsField = value;
            }

            /// <remarks/>
            public proactiveNFType proactive
            {
                get => proactiveField;
                set => proactiveField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class pretrialComplaintsProcedureSettingsNFType
        {

            private dictionaryNFType pretrialComplaintsProcedureField;

            /// <remarks/>
            public dictionaryNFType pretrialComplaintsProcedure
            {
                get => pretrialComplaintsProcedureField;
                set => pretrialComplaintsProcedureField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class monitoringComplianceNFType
        {

            private dictionaryNFType currentControlRoutineField;

            private dictionaryNFType[] inspectionsField;

            private dictionaryNFType[] executiveOfficerResponsibilitiesField;

            private dictionaryNFType[] controlRequirementsField;

            /// <remarks/>
            public dictionaryNFType currentControlRoutine
            {
                get => currentControlRoutineField;
                set => currentControlRoutineField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("inspections")]
            public dictionaryNFType[] inspections
            {
                get => inspectionsField;
                set => inspectionsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("executiveOfficerResponsibilities")]
            public dictionaryNFType[] executiveOfficerResponsibilities
            {
                get => executiveOfficerResponsibilitiesField;
                set => executiveOfficerResponsibilitiesField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("controlRequirements")]
            public dictionaryNFType[] controlRequirements
            {
                get => controlRequirementsField;
                set => controlRequirementsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class roomSettingsNFType
        {

            private bool hasRoomRequirementField;

            private bool hasRoomRequirementFieldSpecified;

            private dictionaryNFType[] roomRequirementsField;

            /// <remarks/>
            public bool hasRoomRequirement
            {
                get => hasRoomRequirementField;
                set => hasRoomRequirementField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool hasRoomRequirementSpecified
            {
                get => hasRoomRequirementFieldSpecified;
                set => hasRoomRequirementFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute("roomRequirements")]
            public dictionaryNFType[] roomRequirements
            {
                get => roomRequirementsField;
                set => roomRequirementsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class indicatorsNFType
        {

            private dictionaryNFType[] availabilityField;

            private dictionaryNFType[] qualityField;

            /// <remarks/>
            [XmlElementAttribute("Availability")]
            public dictionaryNFType[] Availability
            {
                get => availabilityField;
                set => availabilityField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("Quality")]
            public dictionaryNFType[] Quality
            {
                get => qualityField;
                set => qualityField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class enumNFType
        {

            private string codeField;

            /// <remarks/>
            public string code
            {
                get => codeField;
                set => codeField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class approvedNFType
        {

            private dictionaryNFType approvingActTypeField;

            private string approvingActNameField;

            private string approvingPersonRankField;

            private string approvingPersonNameField;

            private bool isCancellationActField;

            private bool isCancellationActFieldSpecified;

            private string detailsOfActCancellationField;

            private string placeApprovalActTemplateField;

            private string npaTemplateField;

            private bool isSpecialOrderField;

            private bool isSpecialOrderFieldSpecified;

            private string numberOfDaysField;

            private dictionaryNFType numberOfDaysUnitField;

            private bool isStatementApprovedByActField;

            private bool isStatementApprovedByActFieldSpecified;

            private dictionaryNFType acceptedDepartmentField;

            private enumNFType typeOfDocumentField;

            /// <remarks/>
            public dictionaryNFType approvingActType
            {
                get => approvingActTypeField;
                set => approvingActTypeField = value;
            }

            /// <remarks/>
            public string approvingActName
            {
                get => approvingActNameField;
                set => approvingActNameField = value;
            }

            /// <remarks/>
            public string approvingPersonRank
            {
                get => approvingPersonRankField;
                set => approvingPersonRankField = value;
            }

            /// <remarks/>
            public string approvingPersonName
            {
                get => approvingPersonNameField;
                set => approvingPersonNameField = value;
            }

            /// <remarks/>
            public bool isCancellationAct
            {
                get => isCancellationActField;
                set => isCancellationActField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isCancellationActSpecified
            {
                get => isCancellationActFieldSpecified;
                set => isCancellationActFieldSpecified = value;
            }

            /// <remarks/>
            public string detailsOfActCancellation
            {
                get => detailsOfActCancellationField;
                set => detailsOfActCancellationField = value;
            }

            /// <remarks/>
            public string placeApprovalActTemplate
            {
                get => placeApprovalActTemplateField;
                set => placeApprovalActTemplateField = value;
            }

            /// <remarks/>
            public string npaTemplate
            {
                get => npaTemplateField;
                set => npaTemplateField = value;
            }

            /// <remarks/>
            public bool isSpecialOrder
            {
                get => isSpecialOrderField;
                set => isSpecialOrderField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isSpecialOrderSpecified
            {
                get => isSpecialOrderFieldSpecified;
                set => isSpecialOrderFieldSpecified = value;
            }

            /// <remarks/>
            [XmlElementAttribute(DataType = "integer")]
            public string numberOfDays
            {
                get => numberOfDaysField;
                set => numberOfDaysField = value;
            }

            /// <remarks/>
            public dictionaryNFType numberOfDaysUnit
            {
                get => numberOfDaysUnitField;
                set => numberOfDaysUnitField = value;
            }

            /// <remarks/>
            public bool isStatementApprovedByAct
            {
                get => isStatementApprovedByActField;
                set => isStatementApprovedByActField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool isStatementApprovedByActSpecified
            {
                get => isStatementApprovedByActFieldSpecified;
                set => isStatementApprovedByActFieldSpecified = value;
            }

            /// <remarks/>
            public dictionaryNFType acceptedDepartment
            {
                get => acceptedDepartmentField;
                set => acceptedDepartmentField = value;
            }

            /// <remarks/>
            public enumNFType typeOfDocument
            {
                get => typeOfDocumentField;
                set => typeOfDocumentField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class responsibleOrganizationSelfAuthorityNFType
        {

            private dictionaryFullNameNFType responsibleOrganizationField;

            private dictionaryNFType[] responsibleEntitiesField;

            /// <remarks/>
            public dictionaryFullNameNFType responsibleOrganization
            {
                get => responsibleOrganizationField;
                set => responsibleOrganizationField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("responsibleEntities")]
            public dictionaryNFType[] responsibleEntities
            {
                get => responsibleEntitiesField;
                set => responsibleEntitiesField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class overviewServiceNFType
        {

            private bool hasExtraterritorialityField;

            private bool hasExtraterritorialityFieldSpecified;

            private string servicefullNameField;

            private dictionaryFullNameNFType arOwnerField;

            /// <remarks/>
            public bool hasExtraterritoriality
            {
                get => hasExtraterritorialityField;
                set => hasExtraterritorialityField = value;
            }

            /// <remarks/>
            [XmlIgnoreAttribute]
            public bool hasExtraterritorialitySpecified
            {
                get => hasExtraterritorialityFieldSpecified;
                set => hasExtraterritorialityFieldSpecified = value;
            }

            /// <remarks/>
            public string servicefullName
            {
                get => servicefullNameField;
                set => servicefullNameField = value;
            }

            /// <remarks/>
            public dictionaryFullNameNFType arOwner
            {
                get => arOwnerField;
                set => arOwnerField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class normativeFieldsType
        {

            private overviewServiceNFType overviewField;

            private responsibleOrganizationSelfAuthorityNFType[] responsibleOrganizationSelfAuthorityField;

            private dictionaryNFType[] responsibleOrganizationDelegateAuthorityField;

            private approvedNFType approvedField;

            private indicatorsNFType indicatorsField;

            private roomSettingsNFType roomSettingsField;

            private dictionaryNFType[] associatedServicesField;

            private monitoringComplianceNFType monitoringComplianceField;

            private pretrialComplaintsProcedureSettingsNFType pretrialComplaintsProcedureSettingsField;

            private subServicesNFType[] subServicesField;

            private templateAdmRegulationSettingNFType templateAdmRegulationSettingField;

            /// <remarks/>
            public overviewServiceNFType overview
            {
                get => overviewField;
                set => overviewField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("responsibleOrganizationSelfAuthority")]
            public responsibleOrganizationSelfAuthorityNFType[] responsibleOrganizationSelfAuthority
            {
                get => responsibleOrganizationSelfAuthorityField;
                set => responsibleOrganizationSelfAuthorityField = value;
            }

            /// <remarks/>
            [XmlArrayItemAttribute("responsibleOrganizationProfiles", IsNullable = false)]
            public dictionaryNFType[] responsibleOrganizationDelegateAuthority
            {
                get => responsibleOrganizationDelegateAuthorityField;
                set => responsibleOrganizationDelegateAuthorityField = value;
            }

            /// <remarks/>
            public approvedNFType approved
            {
                get => approvedField;
                set => approvedField = value;
            }

            /// <remarks/>
            public indicatorsNFType indicators
            {
                get => indicatorsField;
                set => indicatorsField = value;
            }

            /// <remarks/>
            public roomSettingsNFType roomSettings
            {
                get => roomSettingsField;
                set => roomSettingsField = value;
            }

            /// <remarks/>
            [XmlArrayItemAttribute("servicesInfo", IsNullable = false)]
            public dictionaryNFType[] associatedServices
            {
                get => associatedServicesField;
                set => associatedServicesField = value;
            }

            /// <remarks/>
            public monitoringComplianceNFType monitoringCompliance
            {
                get => monitoringComplianceField;
                set => monitoringComplianceField = value;
            }

            /// <remarks/>
            public pretrialComplaintsProcedureSettingsNFType pretrialComplaintsProcedureSettings
            {
                get => pretrialComplaintsProcedureSettingsField;
                set => pretrialComplaintsProcedureSettingsField = value;
            }

            /// <remarks/>
            [XmlElementAttribute("subServices")]
            public subServicesNFType[] subServices
            {
                get => subServicesField;
                set => subServicesField = value;
            }

            /// <remarks/>
            public templateAdmRegulationSettingNFType templateAdmRegulationSetting
            {
                get => templateAdmRegulationSettingField;
                set => templateAdmRegulationSettingField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        [XmlRootAttribute("KCRResponse", Namespace = "urn://rostelekom.ru/KCR/1.0.4", IsNullable = false)]
        public partial class kcrResponseType
        {

            private normativeFieldsType normativeFieldsField;

            private secondaryFieldsType secondaryFieldsField;

            /// <remarks/>
            public normativeFieldsType normativeFields
            {
                get => normativeFieldsField;
                set => normativeFieldsField = value;
            }

            /// <remarks/>
            public secondaryFieldsType secondaryFields
            {
                get => secondaryFieldsField;
                set => secondaryFieldsField = value;
            }
        }

        /// <remarks/>
        [GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [SerializableAttribute]
        [DebuggerStepThroughAttribute]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        [XmlRootAttribute("KCRInfoMessage", Namespace = "urn://rostelekom.ru/KCR/1.0.4", IsNullable = false)]
        public partial class kcrInfoMessageType
        {

            private string kcrIdField;

            private string infoField;

            private string errorField;

            /// <remarks/>
            public string kcrId
            {
                get => kcrIdField;
                set => kcrIdField = value;
            }

            /// <remarks/>
            public string info
            {
                get => infoField;
                set => infoField = value;
            }

            /// <remarks/>
            public string error
            {
                get => errorField;
                set => errorField = value;
            }
        }

        [GeneratedCode("xsd", "4.8.3928.0")]
        [Serializable()]
        [DebuggerStepThrough()]
        [DesignerCategory("code")]
        [XmlType(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class object1Type
        {
            private documentsCategorySFType[] documentsCategoryField;

            /// <remarks/>
            [XmlElementAttribute("documentsCategory")]
            public documentsCategorySFType[] documentsCategory
            {
                get => this.documentsCategoryField;
                set => this.documentsCategoryField = value;
            }
        }

        [GeneratedCode("xsd", "4.8.3928.0")]
        [Serializable()]
        [DebuggerStepThrough()]
        [DesignerCategory("code")]
        [XmlType(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class object2Type
        {
            private requests3SFType[] smevField;


            /// <remarks/>
            [XmlElementAttribute("requests")]
            public requests3SFType[] smev
            {
                get => this.smevField;
                set => this.smevField = value;
            }

        }

        [GeneratedCode("xsd", "4.8.3928.0")]
        [Serializable()]
        [DebuggerStepThrough()]
        [DesignerCategory("code")]
        [XmlType(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class object3Type
        {
            private requests3NFType[] smev3Field;

            /// <remarks/>
            [XmlElementAttribute("requests")]
            public requests3NFType[] smev3
            {
                get => this.smev3Field;
                set => this.smev3Field = value;
            }
        }

        [GeneratedCode("xsd", "4.8.3928.0")]
        [Serializable()]
        [DebuggerStepThrough()]
        [DesignerCategory("code")]
        [XmlType(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class object4Type
        {
            private requestsNoSmevSFType[] requestsField;

            /// <remarks/>
            [XmlElementAttribute("requests")]
            public requestsNoSmevSFType[] requests
            {
                get => this.requestsField;
                set => this.requestsField = value;
            }
        }

        [GeneratedCode("xsd", "4.8.3928.0")]
        [Serializable()]
        [DebuggerStepThrough()]
        [DesignerCategory("code")]
        [XmlType(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class object5Type
        {
            private requestsNoSmevNFType[] requestsField;

            /// <remarks/>
            [XmlElement("requests")]
            public requestsNoSmevNFType[] requests
            {
                get => this.requestsField;
                set => this.requestsField = value;
            }
        }

        [GeneratedCode("xsd", "4.8.3928.0")]
        [Serializable()]
        [DebuggerStepThrough()]
        [DesignerCategory("code")]
        [XmlType(Namespace = "urn://rostelekom.ru/KCR/1.0.4")]
        public partial class object6Type
        {
            private documentsCategoryNFType[] documentsCategoryField;

            /// <remarks/>
            [XmlElementAttribute("documentsCategory")]
            public documentsCategoryNFType[] documentsCategory
            {
                get => this.documentsCategoryField;
                set => this.documentsCategoryField = value;
            }
        }
    }
}