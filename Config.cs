using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace FlowWorks {

  public class Config {

    // helper class -- needed in load/save methods
    public class dictItem {
      [XmlAttribute]
      public string key;
      [XmlAttribute]
      public string value;      
    }

    // constructor
    public Config(string filename) {
      string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      this.pathname = Path.Combine(folder, filename);
      this.dict = new Dictionary<string,string>();
      this.serializer = new XmlSerializer(typeof(dictItem[]), 
                        new XmlRootAttribute() { ElementName = "items" });
    }

    // add, get functions
    public void Add(string key, string value) {
      this.dict[key] = value;
    }
    public void Add(string key, int value) {
      this.Add(key, value.ToString());
    }
    public void Add(string key, double value) {
      this.Add(key, value.ToString());
    }
    public void Add(string key, bool value) {
      this.Add(key, value.ToString());
    }

    public string Get(string key, string defaultVal) {
      string value;
      if (!dict.TryGetValue(key, out value)) {
        value = defaultVal;
      }
      return value;
    }
    public int Get(string key, int defaultVal) {
      int value;
      string valueStr;
      if (dict.TryGetValue(key, out valueStr)) {
        try {
          value = Convert.ToInt32(valueStr);
        }
        catch {
          value = 0;   // string was not a valid integer
        }
      } else {
        value = defaultVal;
      }
      return value;
    }
    public double Get(string key, double defaultVal) {
      double value;
      string valueStr;
      if (dict.TryGetValue(key, out valueStr)) {
        try {
          value = Convert.ToDouble(valueStr);
        }
        catch {
          value = 0;   // string was not a valid double
        }
      } else {
        value = defaultVal;
      }
      return value;    
    }
    public bool Get(string key, bool defaultVal) {
      bool value;
      string valueStr;
      if (dict.TryGetValue(key, out valueStr)) {
        try {
          value = Convert.ToBoolean(valueStr);
        }
        catch {
          value = false;   // string was not a valid bool
        }
      } else {
        value = defaultVal;
      }
      return value;    
    }

    // save/load from file  -- functions return T on failure
    public bool Save() {
      bool failed = false;
      try {
        FileStream stream = new FileStream(this.pathname, FileMode.Create);
        serializer.Serialize(stream, this.dict.Select(kv=>new dictItem(){key=kv.Key,value=kv.Value}).ToArray());
        stream.Close();     
      } catch {
        failed = true;
      }
      return failed;
    }
    public bool Load() {
      bool failed = false;
      try {
        FileStream stream = new FileStream(this.pathname, FileMode.Open);
        this.dict = ((dictItem[])serializer.Deserialize(stream)).ToDictionary(i=>i.key, i=>i.value);
        stream.Close();     
      }
      catch {
        failed = true;
      }
      return failed;
    }

    //
    // private
    //

    private string pathname;
    private Dictionary<string, string> dict;
    private XmlSerializer serializer;
  }
}
