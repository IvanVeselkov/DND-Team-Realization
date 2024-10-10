using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Doc;
using static System.Net.Mime.MediaTypeNames;

namespace DnD
{
    internal class WordDocument
    {
        public void CreatePdfSheet (CharacterSheet character)
        {
            if (character == null)
                return;
            
            var path = Path.GetDirectoryName(Path.GetDirectoryName (Path.GetDirectoryName(Directory.GetCurrentDirectory())));

            Document document = new Document ();
            document.LoadFromFile(Path.Combine(path, "FileTemplate.docx")); //FileTemplate необходимо закинуть в bin...debug
            document.Replace("InputName", character.Name, true, true);
            document.Replace("InputRace", character.Race, true, true);
            document.Replace("InputStr", character.Strenght.ToString(), true, true);
            document.Replace("InputDex", character.Dexterity.ToString(), true, true);
            document.Replace("InputCons", character.Сonstitution.ToString(), true, true);
            document.Replace("InputInt", character.Intelligence.ToString(), true, true);
            document.Replace("InputWis", character.Wisdom.ToString(), true, true);
            document.Replace("InputCharisma", character.Charisma.ToString(), true, true);
            document.Replace("InputHp", character.HitPoints.ToString(), true, true);
            document.Replace("InputArmor", character.ArmorClass.ToString(), true, true);
            document.Replace("InputSpeed", character.Speed.ToString(), true, true);

            document.SaveToFile($"{character.Name} - {character.Race}.pdf", FileFormat.PDF);
            Console.WriteLine("Файл PDF сохранен");
        }
    }
}
