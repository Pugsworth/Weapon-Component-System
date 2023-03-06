using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using ComposedWeaponPlanning;

class Program
{
    static String LimitString(String str, int max_length)
    {
        int len = Math.Min(str.Length, max_length);

        if (str.Length > len) {
            return str.Substring(0, len - 3) + "...";
        }

        return str;
    }

    static void PrintSeparator(int[] widths, Char corner, Char horizontal, Char vertical, Char space)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(corner);

        for (int i = 0; i < widths.Length; i++) {
            sb.Append(new String(horizontal, widths[i] + 2));
            sb.Append(corner);
        }

        Console.WriteLine(sb.ToString());
    }

    /** Prints a row of data to the console. */
    static void PrintRow(object[] data, int[] widths, Char vertical, Char space)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(vertical);

        for (int i = 0; i < data.Length; i++) {
            // Console.WriteLine($"data[{i}]: {data[i]}, widths[{i}]: {widths[i]}");
            String str = LimitString(data[i].ToString(), widths[i]);
            sb.Append(space);
            sb.Append(str);
            sb.Append(new String(space, widths[i] - str.Length));
            sb.Append(space);
            sb.Append(vertical);
        }

        Console.WriteLine(sb.ToString());
    }

    /*
    +-----------------+-----------------+-----------------+-----------------+
    |                 |                 |                 |                 |
    +-----------------+-----------------+-----------------+-----------------+
    |                 |                 |                 |                 |
    +-----------------+-----------------+-----------------+-----------------+
    */

    class Table {
        public List<String> headers = new List<String>();
        // Used for keeping track of the width of each column.
        public List<Column> columns = new List<Column>();
        // Holds the data for each row.
        public List<List<String>> rows = new List<List<String>>();

        public int[] GetColumnWidths()
        {
            int[] widths = new int[columns.Count];

            for (int i = 0; i < columns.Count; i++) {
                widths[i] = columns[i].width;
            }

            return widths;
        }
    }

    class Column {
        public int width = 0;
        // Sets a width value for the column. If the value is less than the current width, it will be ignored.
        public void SetIncreasingWidth(int width)
        {
            if (width > this.width) {
                this.width = width;
            }
        }
    }

    static void DumpObject(object obj)
    {
        const Char corner = '+';
        const Char horizontal = '-';
        const Char vertical = '|';
        const Char space = ' ';
        const int max_column_width = 40;

        Table table = new Table();
        table.columns = new List<Column>() {
            new Column(),
            new Column(),
            new Column()
        };

        table.headers.Add("Name");
        table.headers.Add("Type");
        table.headers.Add("Value");

        table.columns[0].SetIncreasingWidth("Name".Length);
        table.columns[1].SetIncreasingWidth("Type".Length);
        table.columns[2].SetIncreasingWidth("Value".Length);

        var type = obj.GetType();

        // String name = LimitString(obj.ToString() ?? type.Name, max_column_width);

        var properties = type.GetProperties().Except(type.GetDefaultMembers().OfType<PropertyInfo>());

        foreach (var prop in properties) {
            int i = 0;

            var name = prop.Name;
            var typeName = prop.PropertyType.Name;
            var value = prop.GetValue(obj, null).ToString();

            table.columns[i++].SetIncreasingWidth(name.Length);
            table.columns[i++].SetIncreasingWidth(typeName.Length);
            table.columns[i++].SetIncreasingWidth(value.Length);

            // Console.WriteLine($"{indentStr}{prop.Name}: {prop.GetValue(obj, null)}");
            table.rows.Add(new List<String>() {
                prop.Name,
                prop.PropertyType.Name,
                prop.GetValue(obj, null).ToString()
            });

            i++;
        }

        int[] widths = table.GetColumnWidths();

        PrintSeparator(widths, corner, horizontal, vertical, space);
        PrintRow(table.headers.ToArray(), widths, vertical, space);
        PrintSeparator(widths, corner, horizontal, vertical, space);

        foreach (var row in table.rows) {
            PrintRow(row.ToArray(), widths, vertical, space);
            PrintSeparator(widths, corner, horizontal, vertical, space);
        }

        // PrintSeparator(new int[] { max_column_width, max_column_width, max_column_width }, corner, horizontal, vertical, space);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        int width = (int)MathF.Floor(Console.WindowWidth * 0.75f);

        /*
        TextProgressBar progress = new TextProgressBar(width, '[', ']', '=', ' ');
        progress.ShowPercent = true;

        for (int i = 0; i < 100; i++) {
            double frac = (double)i / 100.0;

            progress.SetProgrees((float)frac);

            System.Threading.Thread.Sleep(10);

            ClearLine();
            Console.WriteLine(progress.Render());
        }


        Console.WriteLine(AsciiWeapons.Pistol);
        */

        DumpObject(AsciiWeapons.Pistol);
    }

    static void ClearLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    }
}