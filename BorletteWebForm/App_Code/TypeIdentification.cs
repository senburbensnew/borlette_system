using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TypeIdentification
/// </summary>
public class TypeIdentification
{

    private short _Id;
    private string _Name;
    public TypeIdentification()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public TypeIdentification(short id, string name)
    {
        _Id = id;
        _Name = name;
    }

    public short Id { get => _Id; set => _Id = value; }
    public string Name { get => _Name; set => _Name = value; }


    public static List<TypeIdentification> LoadTypeIdentification()
    {
        List<TypeIdentification> result = new List<TypeIdentification>();
        result.Add(new TypeIdentification(1, "NIF"));
        result.Add(new TypeIdentification(2, "Carte Idendification Nationale"));
        result.Add(new TypeIdentification(3, "PassePort"));


        return result;
    }
}