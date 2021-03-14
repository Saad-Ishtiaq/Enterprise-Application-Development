using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_5
{


    //------------------Lecture Part-3------------------------
    //partial class
    partial class Person3
    {
        private string name;
        private string[] strData = new string[10];

        //indexer
        public string this[int index]
        {
            get => strData[index];
            set => strData[index] = value;
        }


        //properties
        public string Country { get; set; }
        
        //lemda expression : when we have to only get
        public string MyName => this.name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        //when we have to add other functionality with getting and setting
        private string favoritePrimaryColor;
        public string FavoritePrimaryColor
        {
            get
            {
                return favoritePrimaryColor;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "green":
                    case "blue":
                        favoritePrimaryColor = value;
                        break;
                    default:
                        throw new System.ArgumentException(
                        $"{value} is not a primary color. " +
                        "Choose from: red, green, blue.");
                }
            }
        }
    }
}
