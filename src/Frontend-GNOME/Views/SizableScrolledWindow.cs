// Smuxi - Smart MUltipleXed Irc
//
// Copyright (c) 2013 Mirco Bauer <meebey@meebey.net>
//
// Full GPL License: <http://www.gnu.org/licenses/gpl.txt>
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307 USA
using System;

namespace Smuxi.Frontend.Gnome
{
    public class SizableScrolledWindow : Gtk.ScrolledWindow
    {
#if GTK_SHARP_3
        public event EventHandler<SizeRequestedEventArgs> SizeRequestedHeigth;
#endif

        public SizableScrolledWindow() : base()
        {
        }

#if GTK_SHARP_3
        protected override void OnGetPreferredHeight(out int minimum_height, out int natural_height)
        {
            var args = new SizeRequestedEventArgs();
            RaiseSizeRequestedHeight(args);
            minimum_height = args.MinimumSize;
            natural_height = args.NaturalSize;
        }

        protected virtual void RaiseSizeRequestedHeight(SizeRequestedEventArgs e)
        {
            if (SizeRequestedHeigth != null) {
                SizeRequestedHeigth(this, e);
            }
        }
#endif
    }

    public class SizeRequestedEventArgs : EventArgs
    {
        public int MinimumSize { get; set; }
        public int NaturalSize { get; set; }
    }
}
