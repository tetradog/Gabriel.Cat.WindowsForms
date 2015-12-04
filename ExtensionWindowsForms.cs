using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gabriel.Cat.WindowsForms
{
  public static  class ExtensionWindowsForms
    {
        #region ControlExtension

        public static void AddRange(this Control.ControlCollection control, IEnumerable<Control> controles)
        {
            if (controles == null)
                throw new NullReferenceException("IEnumerable<Control> controls to addRange is null...");
            foreach (Control controlPerPosar in controles)
            {
                control.Add(controlPerPosar);

            }
        }
        #endregion
        #region LlistesExtension

        public static void AddRange(this ListBox.ObjectCollection list, IEnumerable<object> objectes)
        {
            if (objectes == null)
                throw new NullReferenceException("IEnumerable<object> objectes to addRange is null...");
            foreach (object obj in objectes)
                list.Add(obj);
        }
        public static void AddRange(this CheckedListBox.ObjectCollection list, IEnumerable<object> objectes)
        {
            if (objectes == null)
                throw new NullReferenceException("IEnumerable<object> objectes to addRange is null...");
            foreach (object obj in objectes)
                list.Add(obj);
        }
        public static void AddRange(this ComboBox.ObjectCollection list, IEnumerable<object> objectes)
        {
            if (objectes == null)
                throw new NullReferenceException("IEnumerable<object> objectes to addRange is null...");
            foreach (object obj in objectes)
                list.Add(obj);
        }
        public static void AddRange(this DataGridViewComboBoxCell.ObjectCollection list, IEnumerable<object> objectes)
        {
            if (objectes == null)
                throw new NullReferenceException("IEnumerable<object> objectes to addRange is null...");
            foreach (object obj in objectes)
                list.Add(obj);
        }
        #endregion
    }
}
