using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevWinfrom
{
    //The attribute that points to the registration method
    //The attribute that points to the registration method
    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemCustomComboBoxEdit : RepositoryItemComboBox
    {

        //The static constructor which calls the registration method
        static RepositoryItemCustomComboBoxEdit() { RegisterCustomEdit(); }

        //Initialize new properties
        public RepositoryItemCustomComboBoxEdit()
        {
        }

        //The unique name for the custom editor
        public const string CustomEditName = "CustomComboBoxEdit";

        //Return the unique name
        public override string EditorTypeName { get { return CustomEditName; } }

        //Register the editor
        public static void RegisterCustomEdit()
        {
            //Icon representing the editor within a container editor's Designer
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(CustomComboBoxEdit), typeof(RepositoryItemCustomComboBoxEdit), typeof(ComboBoxViewInfo), new ButtonEditPainter(), true, null, typeof(DevExpress.Accessibility.PopupEditAccessible)));
        }
    }

    public class CustomComboBoxEdit : ComboBoxEdit
    {
        protected override DevExpress.XtraEditors.Popup.PopupBaseForm CreatePopupForm()
        {
            return new CustomPopupListBoxForm(this);
        }
        //The static constructor which calls the registration method
        static CustomComboBoxEdit() { RepositoryItemCustomComboBoxEdit.RegisterCustomEdit(); }

        //Initialize the new instance
        public CustomComboBoxEdit()
        {
            //...
        }

        private ArrayList m_list = new ArrayList();
        protected override void OnEnter(EventArgs e)
        {
            m_list.Clear();
            m_list.AddRange(this.Properties.Items);
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            this.Properties.Items.Clear();
            this.Properties.Items.AddRange(m_list.ToArray());
            base.OnLeave(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (this.Text != "")
            {
                while (this.Properties.Items.Count > 0)
                {
                    this.Properties.Items.RemoveAt(0);
                }
                foreach (object o in this.m_list)
                {
                    if (GetChineseSpell(o.ToString()).ToLower().Contains(this.Text.ToLower()))
                    {
                        this.Properties.Items.Add(o);
                    }
                }
            }
           // this.Properties.Items.Add("231");
            this.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick;
            this.ShowPopup();
            //.DroppedDown = true;
            this.Cursor = Cursors.Default;
            base.OnTextChanged(e);
            //base.OnTextUpdate(e);
        }

        static public string GetChineseSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }

        static public string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            else
                return cnChar;
        }


        //Return the unique name
        public override string EditorTypeName { get { return RepositoryItemCustomComboBoxEdit.CustomEditName; } }

        //Override the Properties property
        //Simply type-cast the object to the custom repository item type
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomComboBoxEdit Properties
        {
            get { return base.Properties as RepositoryItemCustomComboBoxEdit; }
        }


    }

    public class CustomPopupListBoxForm : PopupListBoxForm
    {
        public CustomPopupListBoxForm(ComboBoxEdit be)
            : base(be)
        {

        }
        protected override PopupListBox CreateListBox()
        {
            return new CustomPopupListBox(this);
        }

    }

    public class CustomPopupListBox : PopupListBox
    {
        public CustomPopupListBox(PopupListBoxForm owner)
            : base(owner)
        {
        }
        protected override BaseStyleControlViewInfo CreateViewInfo()
        {
            return new CustomBaseStyleControlViewInfo(this);
        }
    }

    public class CustomBaseStyleControlViewInfo : PopupListBoxViewInfo
    {
        public CustomBaseStyleControlViewInfo(PopupListBox owner)
            : base(owner)
        {
        }
        //protected override BaseListBoxViewInfo.ItemInfo CreateItemInfo(Rectangle bounds, object item, string text, int index) {
        //    if (item.ToString() != "1") { text = "  " + text; }
        //    return base.CreateItemInfo(bounds, item, text, index);
        //}
    }
}

