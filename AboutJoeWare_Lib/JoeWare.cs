#region © 2017 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AboutJoeWare_Lib
{
    // ----------------------------------------------------
    /// <summary>
    ///     
    /// </summary>

    public class JoeWare
    {
        public static void ShowAboutBox()
        {
            var dlg = new AboutJoeWareDlg();
            dlg.ShowDialog();
        }
    }
}
