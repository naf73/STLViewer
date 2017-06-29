using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STLViewer
{
    partial class AboutSTLViewer : Form
    {
        public AboutSTLViewer(string text)
        {
            InitializeComponent();
            switch (Properties.Settings.Default.Language)
            {
                case "Russian":
                    this.Text = String.Format("О программе {0}", text);
                    this.labelProductName.Text = text;
                    this.labelVersion.Text = String.Format("Версия {0}", AssemblyVersion);
                    this.labelCopyright.Text = AssemblyCopyright;
                    this.labelCompanyName.Text = AssemblyCompany;
                    this.label1.Text = "Менеджер проекта Гочиева Замира" + Environment.NewLine +
                                       "Аналитика, тестирование Зарубина Лариса" + Environment.NewLine +
                                       "Ведущий разработчик C# Нейчев Александр" + Environment.NewLine +
                                       "Разработчик C# Абаев Дмитрий" + Environment.NewLine +
                                       "Разработчик C# Вербкин Игорь" + Environment.NewLine +
                                       "Старший тестировщик Степанова Ирина" + Environment.NewLine +
                                       "Тестировщик Никулин Сергей" + Environment.NewLine +
                                       "Тестировщик Суздалева Мария";
                    break;
                case "English":
                    this.Text = String.Format("About {0}", text);
                    this.labelProductName.Text = text;
                    this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
                    this.labelCopyright.Text = AssemblyCopyright;
                    this.labelCompanyName.Text = AssemblyCompany;
                    this.label1.Text = "Project manager Гочиева Замира" + Environment.NewLine +
                                       "Analyst, QA Зарубина Лариса" + Environment.NewLine +
                                       "Team leader С# Нейчев Александр" + Environment.NewLine +
                                       "developer C# Абаев Дмитрий" + Environment.NewLine +
                                       "developer C# Вербкин Игорь" + Environment.NewLine +
                                       "Senior QA Степанова Ирина" + Environment.NewLine +
                                       "QA Никулин Сергей" + Environment.NewLine +
                                       "QA Суздалева Мария";
                    break;
            }
        }

        #region Методы доступа к атрибутам сборки

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
