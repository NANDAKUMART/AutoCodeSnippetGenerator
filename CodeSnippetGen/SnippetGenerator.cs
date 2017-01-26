using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSnippetGen
{
    public static class SnippetGenerator
    {
        public static TypeCode ConvertTypeToEnum(this Type type)
        {
            if (type == typeof(int)) return TypeCode.Int32;
            if (type == typeof(char)) return TypeCode.Char;
            if (type == typeof(float)) return TypeCode.Single;
            if (type == typeof(double)) return TypeCode.Double;
            if (type == typeof(string)) return TypeCode.String;
            if (type == typeof(bool)) return TypeCode.Boolean;
            if (type == typeof(DateTime)) return TypeCode.DateTime;
            return TypeCode.Empty;
        }

        public static string ConstructArraySnippet(this Type type, string propName)
        {
            var currentMemberSnippet = "";
            var elementType = type.GetElementType();

            if (elementType.IsPrimitiveType())
                currentMemberSnippet = " " + propName + " = new " + type.FullName + " { } ";
            else
            {
                currentMemberSnippet = " " + propName + " = new " + type.FullName + " { \n\t";
                currentMemberSnippet += elementType.ConstructClassSnippet();
                currentMemberSnippet += "\n }";
            }
            return currentMemberSnippet;
        }

        public static string ConstructCollectionValueSnippet(this Type type, string propName)
        {
            return " " + propName + " = new List<" + type.FullName + ">() { } ";
        }

        public static string ConstructCollectionObjectSnippet(this Type type, string propName)
        {
            var currentMemberSnippet = propName + " = " + "new List<" + type.FullName + ">(){\n\t";
            currentMemberSnippet += type.ConstructClassSnippet();
            return currentMemberSnippet += "\n }";
        }

        public static string ConstructMemberSnippet(this Type targetType, string propName)
        {
            string stringifiedSnippet = "";
            if (targetType != null)
            {
                stringifiedSnippet = propName + " = ";
                switch (targetType.ConvertTypeToEnum())
                {
                    case TypeCode.Int32:
                        stringifiedSnippet += 0;
                        break;

                    case TypeCode.Double:
                        stringifiedSnippet += 0.0 + "d";
                        break;

                    case TypeCode.Single:
                        stringifiedSnippet += 0.0 + "f";
                        break;

                    case TypeCode.Char:
                        stringifiedSnippet += "'a'";
                        break;

                    case TypeCode.Boolean:
                        stringifiedSnippet += "true";
                        break;

                    case TypeCode.String:
                        stringifiedSnippet += " String.Empty ";
                        break;

                    case TypeCode.DateTime:
                        stringifiedSnippet += " DateTime.Now ";
                        break;

                    default:
                        stringifiedSnippet += " String.Empty ";
                        break;
                }
            }
            return stringifiedSnippet;
        }

        public static string ConstructClassSnippet(this Type targetType)
        {
            string stringifiedSnippet = "";

            if (targetType.IsClass)
                stringifiedSnippet += "new " + targetType.FullName + "() \n{";

            if (targetType != null)
            {
                var memeberSnippetList = new List<string>();
                var publicPropList = targetType.GetProperties();

                foreach (var prop in publicPropList)
                {
                    var currentMemberSnippet = "";

                    if (prop.PropertyType.IsPrimitiveType())
                    {
                        currentMemberSnippet = prop.PropertyType.ConstructMemberSnippet(prop.Name);
                    }
                    else if (prop.PropertyType.IsArray)
                    {
                        currentMemberSnippet = prop.PropertyType.ConstructArraySnippet(prop.Name);
                    }
                    else if (prop.PropertyType.IsGenericType)
                    {
                        currentMemberSnippet = prop.PropertyType.ConstructGenericSnippet(prop.Name);
                    }
                    else if (prop.PropertyType.IsClass)
                    {
                        currentMemberSnippet = prop.Name + " = " + prop.PropertyType.ConstructClassSnippet();
                    }

                    memeberSnippetList.Add(currentMemberSnippet);
                }

                stringifiedSnippet += " \n" + string.Join(" , \n ", memeberSnippetList) + " \n";
            }

            if (targetType.IsClass)
                stringifiedSnippet += " } ";

            return stringifiedSnippet;
        }

        public static string ConstructGenericSnippet(this Type type, string propName)
        {
            var currentMemberSnippet = "";
            var elementType = type.GetGenericArguments()[0];
            if (elementType.IsPrimitiveType())
                currentMemberSnippet = elementType.ConstructCollectionValueSnippet(propName);
            else
                currentMemberSnippet = elementType.ConstructCollectionObjectSnippet(propName);
            return currentMemberSnippet;
        }

        public static bool IsPrimitiveType(this Type targetType)
        {
            if (targetType == typeof(int) || targetType == typeof(char) || targetType == typeof(float)
              || targetType == typeof(double) || targetType == typeof(string) || targetType == typeof(bool))
                return true;
            return false;
        }
    }
}
