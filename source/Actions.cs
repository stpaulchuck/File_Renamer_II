using System;
using System.Windows.Forms;
using System.IO;

namespace FileRenamer2
{
    /// <summary>
    /// this version of the class just creates the preview of the changes
    /// </summary>
    public static class p
    {
        public static frm_Main frmParent = null;

        public static void prefix()
        {

            string pString, fString;

            pString = frmParent.replaceText.Text;
            if (pString != "")
            {
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        frmParent.DataGridView1[2, i].Value = pString + fString;
                        frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        frmParent.DataGridView1[2, i].Value = "";
                    }
                }
            }
            else
                MessageBox.Show("There is no text to prepend!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void suffix()
        {
            string p1String = "", p2String = "", fString = "", rText = "";
            string[] splitArray = null;

            rText = frmParent.replaceText.Text;
            if (rText != "")
            {
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        splitArray = fString.Split('.');
                        if (splitArray.Length > 1)
                        {
                            p2String = "." + splitArray[splitArray.Length - 1];
                            p1String = fString.Replace(p2String, "");
                        }
                        else
                        {
                            p1String = fString;
                            p2String = "";
                        }
                        frmParent.DataGridView1[2, i].Value = p1String + rText + p2String;
                        frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        frmParent.DataGridView1[2, i].Value = "";
                    }
                }
            }
            else
                MessageBox.Show("There is no text to append!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void infix()
        {
            string p1String = "", p2String = "", fString = "";
            string rText = "", sText = "";
            Int32 inLoc = 0;

            rText = frmParent.replaceText.Text;
            sText = frmParent.searchText.Text;
            if (rText != "" && sText != "")
            {
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        inLoc = fString.IndexOf(sText);
                        if (inLoc >= 0)
                        {
                            p1String = fString.Substring(0, inLoc + sText.Length);
                            p2String = fString.Substring(inLoc + sText.Length);
                            frmParent.DataGridView1[2, i].Value = p1String + rText + p2String;
                            frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                        }
                        else
                        {
                            MessageBox.Show("Search string not found in: \n" + fString,
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmParent.DataGridView1[2, i].Value = "search string not found";
                            frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                        frmParent.DataGridView1[2, i].Value = "";
                }
            }
            else
            {
                if (rText == "")
                    MessageBox.Show("There is no text to insert!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (sText == "")
                    MessageBox.Show("There is no text value to search for!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void replace()
        {
            string fString = "", rText = "", sText = "";
            Int32 inLoc = 0;

            rText = frmParent.replaceText.Text;
            sText = frmParent.searchText.Text;
            if (sText != "")
            {
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        inLoc = fString.IndexOf(sText);
                        if (inLoc >= 0)
                        {
                            frmParent.DataGridView1[2, i].Value = fString.Replace(sText, rText);
                            frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                        }
                        else
                        {
                            //MessageBox.Show("Search string not found in: \n" + fString,
                            //"Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmParent.DataGridView1[2, i].Value = "search string not found";
                            frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                        frmParent.DataGridView1[2, i].Value = "";
                }
            }
            else
            {
                if (sText == "")
                    MessageBox.Show("There is no text value to search for!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void numBefore()
        {
            string pString = "", fString = "";
            Int32 pNum = 0, pInc = 0;
            string pText = "", eText = "";

            pString = frmParent.startNumber.Text;
            int iTemp = 0; // dummy for the next test
            if (int.TryParse(pString, out iTemp) == true && pString != "")
            {
                pNum = iTemp;
                int.TryParse(frmParent.stepNumber.Text, out pInc);
                pText = frmParent.numberPrefix.Text.Trim();
                eText = frmParent.numberSuffix.Text.Trim();
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        frmParent.DataGridView1[2, i].Value = pText + pNum.ToString() + eText + fString;
                        frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                        pNum = pNum + pInc;
                    }
                    else
                        frmParent.DataGridView1[2, i].Value = "";
                }
            }
            else
                MessageBox.Show("There is no number to prepend!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        public static void numAfter()
        {
            string pString = "", fString = "";
            Int32 pNum = 0, pInc = 0;
            string[] splitArray = null;
            string pText = "", eText = "", p1String = "", p2String = "";

            pString = frmParent.startNumber.Text;
            if (Int32.TryParse(pString, out pNum) == true && pString != "")
            {
                Int32.TryParse(frmParent.stepNumber.Text, out pInc);
                pText = frmParent.numberPrefix.Text.Trim();
                eText = frmParent.numberSuffix.Text.Trim();
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        splitArray = fString.Split('.');
                        if (splitArray.Length > 1)
                        {
                            p2String = "." + splitArray[splitArray.Length - 1];
                            p1String = fString.Replace(p2String, "");
                        }
                        else
                        {
                            p1String = fString;
                            p2String = "";
                        }
                        frmParent.DataGridView1[2, i].Value = p1String + pText + pNum.ToString() + eText + p2String;
                        frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                        pNum = pNum + pInc;
                    }
                    else
                        frmParent.DataGridView1[2, i].Value = "";
                }
            }
            else
                MessageBox.Show("There is no number to append!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void numInfix()
        {
            string p1String = "", p2String = "", fString = "", sText = "";
            Int32 inLoc = 0, pInc = 0, pNum = 0;
            string pString = "", pText = "", eText = "";

            pString = frmParent.startNumber.Text;
            sText = frmParent.searchText.Text;
            if (pString != "" && sText != "" && Int32.TryParse(pString, out pNum) == true)
            {
                Int32.TryParse(frmParent.stepNumber.Text, out pInc);
                pText = frmParent.numberPrefix.Text.Trim();
                eText = frmParent.numberSuffix.Text.Trim();
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        inLoc = fString.IndexOf(sText);
                        if (inLoc > 0)
                        {
                            p1String = fString.Substring(0, inLoc + sText.Length);
                            p2String = fString.Substring(inLoc + sText.Length);
                            frmParent.DataGridView1[2, i].Value = p1String + pText + pNum.ToString() + eText + p2String;
                            frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                            pNum = pNum + pInc;
                        }
                        else
                        {
                            //MessageBox.Show("Search string not found in: " & vbCrLf & fString, _
                            // "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            frmParent.DataGridView1[2, i].Value = "search string not found";
                            frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                        frmParent.DataGridView1[2, i].Value = "";
                }
            }
            else
            {
                if (pString == "")
                    MessageBox.Show("There is no number to insert!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (sText == "")
                    MessageBox.Show("There is no text value to search for!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }

    /// <summary>
    /// This version of the class actually executes the changes to the file names
    /// </summary>
    public static class x
    {
        public static frm_Main frmParent = null;

        public static void prefix()
        {
            string pString, fString;

            pString = frmParent.replaceText.Text;
            if (pString != "")
            {
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        frmParent.DataGridView1[2, i].Value = pString + fString;
                        frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                        File.Move(frmParent.sCurrentDirectoryPath + "\\" + fString, frmParent.sCurrentDirectoryPath + "\\" + pString + fString);
                    }
                    else
                    {
                        frmParent.DataGridView1[2, i].Value = "";
                    }
                }
                frmParent.GetFiles();
            }
            else
                MessageBox.Show("There is no text to prepend!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void suffix()
        {
            string p1String = "", p2String = "", fString = "", rText = "";
            string[] splitArray = null;

            rText = frmParent.replaceText.Text;
            if (rText != "")
            {
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        splitArray = fString.Split('.');
                        if (splitArray.Length > 1)
                        {
                            p2String = "." + splitArray[splitArray.Length - 1];
                            p1String = fString.Replace(p2String, "");
                        }
                        else
                        {
                            p1String = fString;
                            p2String = "";
                        }
                        frmParent.DataGridView1[2, i].Value = p1String + rText + p2String;
                        frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                        File.Move(frmParent.sCurrentDirectoryPath + "\\" + fString, frmParent.sCurrentDirectoryPath + "\\" + p1String + rText + p2String);
                    }
                    else
                    {
                        frmParent.DataGridView1[2, i].Value = "";
                    }
                }
                frmParent.GetFiles();
            }
            else
                MessageBox.Show("There is no text to append!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void infix()
        {
            string p1String = "", p2String = "", fString = "";
            string rText = "", sText = "";
            Int32 inLoc = 0;

            rText = frmParent.replaceText.Text;
            sText = frmParent.searchText.Text;
            if (rText != "" && sText != "")
            {
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        inLoc = fString.IndexOf(sText);
                        if (inLoc >= 0)
                        {
                            p1String = fString.Substring(0, inLoc + sText.Length);
                            p2String = fString.Substring(inLoc + sText.Length);
                            frmParent.DataGridView1[2, i].Value = p1String + rText + p2String;
                            frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                            File.Move(frmParent.sCurrentDirectoryPath + "\\" + fString, frmParent.sCurrentDirectoryPath + "\\" + p1String + rText + p2String);
                        }
                        else
                        {
                            MessageBox.Show("Search string not found in: \n" + fString,
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmParent.DataGridView1[2, i].Value = "search string not found";
                            frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                        frmParent.DataGridView1[2, i].Value = "";
                }
                frmParent.GetFiles();
            }
            else
            {
                if (rText == "")
                    MessageBox.Show("There is no text to insert!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (sText == "")
                    MessageBox.Show("There is no text value to search for!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void replace()
        {
            string fString = "", rText = "", sText = "", pString = "";
            Int32 inLoc = 0;

            rText = frmParent.replaceText.Text;
            sText = frmParent.searchText.Text;
            if (sText != "")
            {
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        inLoc = fString.IndexOf(sText);
                        if (inLoc >= 0)
                        {
                            pString = fString.Replace(sText, rText);
                            frmParent.DataGridView1[2, i].Value = pString;
                            frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                            File.Move(frmParent.sCurrentDirectoryPath + "\\" + fString, frmParent.sCurrentDirectoryPath + "\\" + pString);
                        }
                        else
                        {
                            //MessageBox.Show("Search string not found in: \n" + fString,
                            //"Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmParent.DataGridView1[2, i].Value = "search string not found";
                            frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                        frmParent.DataGridView1[2, i].Value = "";
                }
                frmParent.GetFiles();
            }
            else
            {
                if (sText == "")
                    MessageBox.Show("There is no text value to search for!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void numbefore()
        {
            string pString = "", fString = "";
            Int32 pNum = 0, pInc = 0;
            string pText = "", eText = "";

            pString = frmParent.startNumber.Text;
            int iTemp = 0; // dummy for the next test
            if (int.TryParse(pString, out iTemp) == true && pString != "")
            {
                pNum = iTemp;
                int.TryParse(frmParent.stepNumber.Text, out pInc);
                pText = frmParent.numberPrefix.Text.Trim();
                eText = frmParent.numberSuffix.Text.Trim();
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        frmParent.DataGridView1[2, i].Value = pText + pNum.ToString() + eText + fString;
                        frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                        pNum = pNum + pInc;
                        File.Move(frmParent.sCurrentDirectoryPath + "\\" + fString, frmParent.sCurrentDirectoryPath + "\\" + pText + pNum.ToString() + eText + fString);
                    }
                    else
                        frmParent.DataGridView1[2, i].Value = "";
                }
                frmParent.GetFiles();
            }
            else
                MessageBox.Show("There is no number to prepend!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        public static void numafter()
        {
            string pString = "", fString = "";
            Int32 pNum = 0, pInc = 0;
            string[] splitArray = null;
            string pText = "", eText = "", p1String = "", p2String = "";

            pString = frmParent.startNumber.Text;
            if (Int32.TryParse(pString, out pNum) == true && pString != "")
            {
                Int32.TryParse(frmParent.stepNumber.Text, out pInc);
                pText = frmParent.numberPrefix.Text.Trim();
                eText = frmParent.numberSuffix.Text.Trim();
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        splitArray = fString.Split('.');
                        if (splitArray.Length > 1)
                        {
                            p2String = "." + splitArray[splitArray.Length - 1];
                            p1String = fString.Replace(p2String, "");
                        }
                        else
                        {
                            p1String = fString;
                            p2String = "";
                        }
                        frmParent.DataGridView1[2, i].Value = p1String + pText + pNum.ToString() + eText + p2String;
                        frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                        pNum = pNum + pInc;
                        File.Move(frmParent.sCurrentDirectoryPath + "\\" + fString, frmParent.sCurrentDirectoryPath + "\\" + p1String + pText + pNum.ToString() + eText + p2String);
                    }
                    else
                        frmParent.DataGridView1[2, i].Value = "";
                }
                frmParent.GetFiles();
            }
            else
                MessageBox.Show("There is no number to append!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void numInfix()
        {
            string p1String = "", p2String = "", fString = "", sText = "";
            Int32 inLoc = 0, pInc = 0, pNum = 0;
            string pString = "", pText = "", eText = "";

            pString = frmParent.startNumber.Text;
            sText = frmParent.searchText.Text;
            if (pString != "" && sText != "" && Int32.TryParse(pString, out pNum) == true)
            {
                Int32.TryParse(frmParent.stepNumber.Text, out pInc);
                pText = frmParent.numberPrefix.Text.Trim();
                eText = frmParent.numberSuffix.Text.Trim();
                for (int i = 0; i < frmParent.DataGridView1.Rows.Count; i++)
                {
                    if ((bool)frmParent.DataGridView1[0, i].Value == true)
                    {
                        fString = frmParent.DataGridView1[1, i].Value.ToString();
                        inLoc = fString.IndexOf(sText);
                        if (inLoc > 0)
                        {
                            p1String = fString.Substring(0, inLoc + sText.Length);
                            p2String = fString.Substring(inLoc + sText.Length);
                            frmParent.DataGridView1[2, i].Value = p1String + pText + pNum.ToString() + eText + p2String;
                            frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Blue;
                            pNum = pNum + pInc;
                            File.Move(frmParent.sCurrentDirectoryPath + "\\" + fString, frmParent.sCurrentDirectoryPath + "\\" + p1String + pText + pNum.ToString() + eText + p2String);
                        }
                        else
                        {
                            //MessageBox.Show("Search string not found in: " & vbCrLf & fString, _
                            // "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            frmParent.DataGridView1[2, i].Value = "search string not found";
                            frmParent.DataGridView1[2, i].Style.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                        frmParent.DataGridView1[2, i].Value = "";
                }
                frmParent.GetFiles();
            }
            else
            {
                if (pString == "")
                    MessageBox.Show("There is no number to insert!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (sText == "")
                    MessageBox.Show("There is no text value to search for!", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
