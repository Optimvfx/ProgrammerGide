using GraphShow;
using GraphVisualizetion;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var visualizetion = new GraphShower(new Visualizer());

            visualizetion.ShowNHardnes(false);
            visualizetion.ShowEqlidAlgoritm();
            visualizetion.ShowSortAlgoritms();
            visualizetion.ShowSearchAlgoritms();
        }
    }
}
