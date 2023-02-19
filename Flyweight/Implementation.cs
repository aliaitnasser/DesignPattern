using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
	/// <summary>
	/// Flyweight
	/// </summary>
	public interface ICharacter
	{
		void Draw(string fontFamily, int fontSize);
	}


	/// <summary>
	/// Concrete Flyweight
	/// </summary>
	public class CharacterA: ICharacter
	{
		private char _actualCharacter = 'a';
		private string _fontFamily = string.Empty;
		private int _fontSize;

		public void Draw(string fontFamily, int fontSize)
		{
			_fontSize = fontSize;
			_fontFamily = fontFamily;
			Console.WriteLine($"Drawing {_actualCharacter}, {_fontFamily}, {_fontSize}");
		}
	}

	/// <summary>
	/// Concrete Flyweight
	/// </summary>
	public class CharacterB: ICharacter
	{
		private char _actualCharacter = 'b';
		private string _fontFamily = string.Empty;
		private int _fontSize;

		public void Draw(string fontFamily, int fontSize)
		{
			_fontSize = fontSize;
			_fontFamily = fontFamily;
			Console.WriteLine($"Drawing {_actualCharacter}, {_fontFamily}, {_fontSize}");
		}
	}

	public class FlyweithFactory
	{
		private readonly Dictionary<char, ICharacter> _characters = new ();

		public ICharacter? GetCharacter(char key)
		{
			// Does the dictionary contain the one we need
			if(_characters.ContainsKey(key))
			{
				Console.WriteLine("Character reuse.");
				return _characters[key];
			}
			// The Character is not in the dictionary
			// Create it, store it, return it.
			Console.WriteLine("Character creation.");
			switch (key)
			{
				case 'a':
					_characters.Add(key, new CharacterA());
					return _characters[key];
				case 'b':
					_characters.Add(key, new CharacterB());
					return _characters[key];
			};
			return null;
		}
	}
}
