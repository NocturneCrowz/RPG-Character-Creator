using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    class CharacterInfo
    {
        // Character's basic information
        private string _dateOfBirth;
        private string _placeOfBirth;
        private string _name;
        private string _sex;
        private int _age;
        private int _height;
        private int _weight;
        private string _size;
        private string _hair;
        private string _eyes;
        private string _skinTone;

        // Those functions will let me acquire and write the proper data of the character
        public string DateOfBirth { get => this._dateOfBirth; set => this._dateOfBirth = value; }
        public string PlaceOfBirth { get => this._placeOfBirth; set => this._placeOfBirth = value; }
        public string Name { get => this._name; set => this._name = value; }
        public string Sex { get => this._sex; set => this._sex = value; }
        public int Age { get => this._age; set => this._age = value; }
        public int Height { get => this._height; set => this._height = value; }
        public int Weight { get => this._weight; set => this._weight = value; }
        public string Size { get => this._size; set => this._size = value; }
        public string Hair { get => this._hair; set => this._hair = value; }
        public string Eyes { get => this._eyes; set => this._eyes = value; }
        public string SkinTone { get => this._skinTone; set => this._skinTone = value; }

    } //Class
} //Namespace