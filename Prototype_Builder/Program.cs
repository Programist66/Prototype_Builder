using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    internal class Program
    {

        public interface ICloneable
        {
            ICloneable Clone();
        }


        public class TrampControl : ICloneable
        {
            public virtual ICloneable Clone()
            {
                return MemberwiseClone() as ICloneable;
            }
        }


        public class StaffTranspControl : TrampControl
        {
            public string StaffBinded { get; set; }

            public override ICloneable Clone()
            {
                return MemberwiseClone() as ICloneable;
            }
        }


        public class NoteTranspControl : StaffTranspControl
        {
            public int NoteTranspControlValue { get; set; }

            public override ICloneable Clone()
            {
                return MemberwiseClone() as ICloneable;
            }
        }


        public class Graphic : ICloneable
        {
            public virtual ICloneable Clone()
            {
                return MemberwiseClone() as ICloneable;
            }
        }


        public class Staff : Graphic
        {
            public NoteTranspControl NoteTranspControl { get; set; }

            public override ICloneable Clone()
            {
                var clone = MemberwiseClone() as Staff;
                clone.NoteTranspControl = NoteTranspControl.Clone() as NoteTranspControl;
                return clone;
            }
        }


        public class MusicalNote : Graphic
        {
            public NoteTranspControl ControlNote { get; set; }

            public override ICloneable Clone()
            {
                var clone = MemberwiseClone() as MusicalNote;
                clone.ControlNote = ControlNote.Clone() as NoteTranspControl;
                return clone;
            }
        }


        public abstract class Tool : ICloneable
        {
            public virtual ICloneable Clone()
            {
                return MemberwiseClone() as ICloneable;
            }
        }


        public class RelocationTool : Tool
        {
            public override ICloneable Clone()
            {
                return MemberwiseClone() as ICloneable;
            }
        }


        public class GraphicTool : Tool
        {
            public override ICloneable Clone()
            {
                return MemberwiseClone() as ICloneable;
            }
        }


        public class RotateTool : Tool
        {
            public override ICloneable Clone()
            {
                return MemberwiseClone() as ICloneable;
            }
        }

        // Строитель 

        public class ASCIIText
        {
            public StringBuilder Content { get; } = new StringBuilder();

            public override string ToString() => Content.ToString();
        }

        public class PDFText
        {
            public StringBuilder Content { get; } = new StringBuilder();

            public override string ToString()
            {
                return Content.ToString();
            }
        }

        public class TextWidget
        {
            public StringBuilder Content { get; } = new StringBuilder();

            public override string ToString()
            {
                return Content.ToString();
            }
        }


        public abstract class TextConverter
        {
            public abstract void ConvertCharacter(char c);
            public abstract void ConvertParagraph();
        }


        public class ASCIIConverter : TextConverter
        {
            private ASCIIText asciiText = new ASCIIText();
            public override void ConvertCharacter(char c)
            {
                asciiText.Content.Append(c);
            }

            public override void ConvertParagraph()
            {
                asciiText.Content.AppendLine("\n");
            }

            public ASCIIText GetResult()
            {
                return asciiText;
            }
        }

        public class PDFConverter : TextConverter
        {
            private PDFText pdfText = new PDFText();
            public override void ConvertCharacter(char c)
            {
                pdfText.Content.Append(c);
            }

            public override void ConvertParagraph()
            {
                pdfText.Content.AppendLine("\n");
            }

            public PDFText GetResult()
            {
                return pdfText;
            }
        }

        public class TextWidgetConverter : TextConverter
        {
            private TextWidget textWidget = new TextWidget();
            public override void ConvertCharacter(char c)
            {
                textWidget.Content.Append(c);
            }

            public override void ConvertParagraph()
            {
                textWidget.Content.AppendLine("\n");
            }

            public TextWidget GetResult()
            {
                return textWidget;
            }
        }


        public class RTFReader
        {
            private TextConverter converter;

            public RTFReader(TextConverter converter)
            {
                this.converter = converter;
            }

            public void ParseRTF(string rtf)
            {
                foreach (char c in rtf)
                {
                    if (c == '\n')
                    {
                        converter.ConvertParagraph();
                    }
                    else
                    {
                        converter.ConvertCharacter(c);
                    }
                }
            }
        }
        static void Main(string[] args)
        {


        }
    }
}