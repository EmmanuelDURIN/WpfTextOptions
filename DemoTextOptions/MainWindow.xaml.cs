using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoTextOptions
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Ajout d'une valuer par défaut en début de liste
            itemsControlTextModes.ItemsSource = new List<TextMode> { null }.Concat(
                ((Enum.GetValues(typeof(TextHintingMode))) as IEnumerable<TextHintingMode>)
                    .SelectMany
                    (
                        thm => ((Enum.GetValues(typeof(TextFormattingMode))) as IEnumerable<TextFormattingMode>)
                            .Select
                            (
                                tfm => new TextMode
                                {
                                    TextFormattingMode = tfm,
                                    TextHintingMode = thm
                                }
                            )
                    )
                    .SelectMany
                    (
                        tm => ((Enum.GetValues(typeof(TextRenderingMode))) as IEnumerable<TextRenderingMode>)
                               .Select
                               (
                                    trm =>
                                       {
                                           tm.TextRenderingMode = trm;
                                           return tm;
                                       }
                               )
                )
            );
        }
    }
}
