﻿using System.Text;

namespace OsteoYoga.Display.Helpers
{
    public class StringHelper
    {
        private static StringHelper _instance;

        public static StringHelper Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        public static StringHelper GetInstance()
        {
            return _instance ?? (_instance = new StringHelper());
        }

        public virtual string ToJavascript(string val)
        {
            val = val.Replace("é", "\\351");
            val = val.Replace("è", "\\350");
            val = val.Replace("ê", "\\352");
            val = val.Replace("à", "\\340");
            val = val.Replace("&#39;", "'");
            return val;
        }

        public static string EncodeJsString(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\"");
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        int i = (int)c;
                        if (i < 32 || i > 127)
                        {
                            sb.AppendFormat("\\u{0:X04}", i);
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            sb.Append("\"");

            return sb.ToString();
        }

    }
}