using System.Globalization;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Controllers.Sistema
{
    public class CambiarIdiomaController : WindowController
    {
        private readonly SingleChoiceAction _chooseFormattingCulture;
        private readonly SingleChoiceAction _chooseLanguage;
        public readonly string DefaultCultureCaption;
        private readonly string _defaultCultureName = CultureInfo.InvariantCulture.TwoLetterISOLanguageName;
        private readonly string _defaultLanguageCaption;

        private string _systemUserLanguage;

        public CambiarIdiomaController()
        {
            TargetWindowType = WindowType.Main;
            _defaultLanguageCaption = CaptionHelper.DefaultLanguage;
            //defaultCultureCaption = CaptionHelper.GetLocalizedText("Texts", "DefaultCulture");
            DefaultCultureCaption = CaptionHelper.GetLocalizedText("Texts", "es-AR");

            StoreDefaultCulture();

            _chooseLanguage = new SingleChoiceAction(this, "ChooseLanguage", PredefinedCategory.Tools);
            _chooseLanguage.Items.Add(new ChoiceActionItem(_defaultLanguageCaption, _defaultLanguageCaption,
                _defaultLanguageCaption));
            _chooseLanguage.Items.Add(new ChoiceActionItem("es-AR", "Español (Argentina)", "es-AR"));
            _chooseLanguage.SelectedIndex = 0;

            _chooseFormattingCulture = new SingleChoiceAction(this, "ChooseFormattingCulture", PredefinedCategory.Tools);
            _chooseFormattingCulture.Items.Add(new ChoiceActionItem(DefaultCultureCaption, DefaultCultureCaption,
                _systemUserLanguage));
            _chooseFormattingCulture.Items.Add(new ChoiceActionItem("es-AR", "Español (Argentina)", "es-AR"));
            _chooseFormattingCulture.SelectedIndex = 0;
        }

        public SingleChoiceAction ChooseLanguage
        {
            get { return _chooseLanguage; }
        }

        public SingleChoiceAction ChooseFormattingCulture
        {
            get { return _chooseFormattingCulture; }
        }

        private void StoreDefaultCulture()
        {
            _systemUserLanguage = CultureInfo.CurrentCulture.Name;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            //StoreDefaultCulture();

            //ChoiceActionItem currentLanguageItem = ChooseLanguage.Items.Find(Application.Model.CurrentAspect, ChoiceActionItemFindType.NonRecursive, ChoiceActionItemFindTarget.Leaf);
            ChoiceActionItem currentLanguageItem =
                ChooseLanguage.Items.Find(((IModelApplicationServices) (Application.Model)).CurrentAspect,
                    ChoiceActionItemFindType.NonRecursive, ChoiceActionItemFindTarget.Leaf);
            if (currentLanguageItem != null)
            {
                ChooseLanguage.SelectedIndex = ChooseLanguage.Items.IndexOf(currentLanguageItem);
            }
            //ChooseFormattingCulture.SelectedIndex = ChooseFormattingCulture.Items.IndexOf(ChooseFormattingCulture.Items.Find(System.Threading.Thread.CurrentThread.CurrentCulture.Name, ChoiceActionItemFindType.Recursive, ChoiceActionItemFindTarget.Any));

            _chooseFormattingCulture.Execute += ChooseFormattingCulture_Execute;
            _chooseLanguage.Execute += ChooseLanguage_Execute;
        }

        protected override void OnDeactivated()
        {
            _chooseLanguage.Execute -= ChooseLanguage_Execute;
            _chooseFormattingCulture.Execute -= ChooseFormattingCulture_Execute;

            base.OnDeactivated();
        }

        private void ChooseLanguage_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var newLanguageName = e.SelectedChoiceActionItem.Data as string;
            if (newLanguageName == _defaultLanguageCaption)
                newLanguageName = _defaultCultureName;

            Application.SetLanguage(newLanguageName);
        }

        private void ChooseFormattingCulture_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var newCultureName = e.SelectedChoiceActionItem.Data as string;
            if (newCultureName == _defaultLanguageCaption)
                newCultureName = _systemUserLanguage;

            Application.SetFormattingCulture(newCultureName);
        }
    }
}