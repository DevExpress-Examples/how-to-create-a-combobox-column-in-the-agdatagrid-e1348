using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DevExpress.AgDataGrid;

namespace ComboInGridExample {
    public partial class Page : UserControl {
        public Page() {
            InitializeComponent();
        }
    }
    public class MyGrid : AgDataGrid {
        protected override void OnCurrentEditorLostFocus(object sender, RoutedEventArgs e) {
            if(CurrentEditor is ComboBox)
                return;
            else
                base.OnCurrentEditorLostFocus(sender, e);
        }
    }
    public class DataSourceNamesDictionary : List<string> {
        public DataSourceNamesDictionary() {
            foreach(Person p in new Persons()) {
                if(!Contains(p.Name)) {
                    Add(p.Name);
                }
            }
        }
    }
    public class Person {
        public int ID { get; set; }
        public string Name { get; set; }
        public Person(int i) {
            ID = i;
            Name = "John_" + i.ToString();
        }
    }
    public class Persons : List<Person> {
        public Persons() {
            for(int i = 0; i < 10; i++) {
                Add(new Person(i));
            }
        }
    }

}
