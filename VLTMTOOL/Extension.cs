using C1.Win.C1List;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLTMTool
{
    public static class Extension
    {
        internal static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void SetC1ComboVisibleFields(this Form frm, Control ctl, bool visible = false)
        {
            try
            {
                foreach (Control item in ctl.Controls)
                {
                    if (item.GetType() == typeof(C1Combo))
                    {
                        changeComboVisibleFields((C1Combo)item, visible);
                    }
                    if (item.HasChildren)
                    {
                        SetC1ComboVisibleFields(frm, item, visible);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }
        private static void changeComboVisibleFields(C1Combo item, bool visible)
        {
            item.ExtendRightColumn = true;
            item.ColumnHeaders = false;
            if (String.IsNullOrEmpty(item.DisplayMember)) return;



            foreach (Split split in item.Splits)
            {
                foreach (C1DisplayColumn columnDisplay in split.DisplayColumns)
                {
                    if (String.IsNullOrWhiteSpace(columnDisplay.DataColumn.DataField)) continue;



                    if (columnDisplay.DataColumn.DataField != item.DisplayMember)
                    {
                        columnDisplay.Visible = visible;
                    }
                }



            }
        }
    }
}
