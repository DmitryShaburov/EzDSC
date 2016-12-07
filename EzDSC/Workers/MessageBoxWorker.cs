using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EzDSC
{
    internal class MessageBoxWorker
    {
        public static DialogResult SameItemExists(Form parent, string text)
        {
            return MessageBox.Show(parent,
                string.Concat(text, Strings.UI_Text_SameAlreadyExists),
                Strings.UI_Caption_Error,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        public static DialogResult Done(Form parent, string text)
        {
            return MessageBox.Show(parent,
                text,
                Strings.UI_Caption_Done,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static DialogResult ConfirmDelete(Form parent, string text)
        {
            return MessageBox.Show(parent,
                string.Concat(Strings.UI_Text_DoYouWantToDelete, text, "?"),
                Strings.UI_Caption_ConfirmDelete,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }

        public static DialogResult CannotDeleteAreUsed(Form parent, string text, HashSet<string> usages)
        {
            return MessageBox.Show(parent,
                string.Concat(text, Environment.NewLine, string.Join(Environment.NewLine, usages)),
                Strings.UI_Caption_Error,
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }
    }
}
