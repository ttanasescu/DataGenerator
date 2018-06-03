using System;
using RegExGenerator.Tokens;

namespace RegExGenerator
{
    public class RegExParser
    {
        private string _input;
        private int _position = 1;

        public RegExParser(string input)
        {
            _input = input;
        }

        public RegEx Parse()
        {
            var regEx = Expression();
            if (NotDone())
            {
                throw new RegExParsingException($"Unexpected character: \'{Peek()}\' at position {_position}.", _position);
            }

            return regEx;
        }

        #region Parsing

        private bool NotDone()
        {
            return _input.Length > 0;
        }

        private char Peek()
        {
            if (_input.Length < 1)
                throw new RegExParsingException($"Nothing found at position {_position}.",_position);
            else
                return _input[0];
        }

        private void Remove(char c)
        {
            if (Peek() == c)
            {
                _input = _input.Substring(1);
                _position++;
            }
            else
            {
                throw new RegExParsingException($"At position {_position} expecting character: '{c}'.\nFound: '{Peek()}'.", _position);
            }
        }

        private char Pop()
        {
            var c = Peek();
            Remove(c);
            return c;
        }

        #endregion

        #region Words

        private RegEx Expression()
        {
            var term = Term();

            if (NotDone() && Peek() == '|')
            {
                Remove('|');
                var regex = Expression();
                return new Choice(term, regex);
            }
            else
            {
                return term;
            }
        }

        private RegEx Term()
        {
            RegEx factor = RegEx.Epsilon;

            while (NotDone() && Peek() != ')' && Peek() != '|')
            {
                var nextFactor = Factor();
                factor = new Sequence(factor, nextFactor);
            }

            return factor;
        }

        private RegEx Factor()
        {
            var @base = Base();

            if (NotDone())
            {
                switch (Peek())
                {
                    case '*':
                        Remove('*');
                        @base = new Factor(@base, new Quantifier());
                        break;
                    case '+':
                        Remove('+');
                        @base = new Factor(@base, new Quantifier(1));
                        break;
                    case '?':
                        Remove('?');
                        @base = new Factor(@base, new Quantifier(0, 1));
                        break;
                    case '{':
                        @base = new Factor(@base, Occurrence());
                        break;
                }
            }

            return @base;
        }

        private Quantifier Occurrence()
        {
            switch (Peek())
            {
                case '{':
                {
                    Remove('{');

                    int? max = null;
                    var min = Number();

                    if (min == null)
                    {
                        throw new RegExParsingException($"Unexpected character: \'{Peek()}\' at position {_position}.", _position);
                        }

                    if (Peek() == ',')
                    {
                        Remove(',');
                        max = Number();
                    }

                    var occuranceces = new Quantifier((int) min, (int)min);

                    if (max != null)
                    {
                        occuranceces.Maximum = (int) max;
                    }

                    Remove('}');

                    return occuranceces;
                }
                default:
                    throw new RegExParsingException($"Unexpected character: \'{Peek()}\' at position {_position}.", _position);
            }
        }

        private int? Number()
        {
            var str = string.Empty;

            while (char.IsDigit(Peek()))
            {
                str += Pop();
            }

            if (int.TryParse(str, out int number))
            {
                return number;
            }

            return null;
        }

        private RegEx Base()
        {
            switch (Peek())
            {
                case '(':
                    Remove('(');
                    var r = Expression();
                    Remove(')');
                    return r;
                case '[':
                    Remove('[');
                    var p = Pick();
                    Remove(']');
                    return p;
                case '.':
                    Remove('.');
                    return new AnyCharacter();
                case '*':
                case '+':
                case '?':
                    throw new RegExParsingException($"Unexpected character: \'{Peek()}\' at position {_position}.", _position);
                default:
                    return Basic();
            }
        }

        private Pick Pick()
        {
            var excluding = false;

            if (Peek() == '^')
            {
                Remove('^');
                excluding = true;
            }

            var pick = new Pick(excluding);
            
            while (NotDone() && Peek() != ']')
            {
                var firstsPosition = _position;
                var first = Basic();

                if (first is Terminal f)
                {
                    char current = f.Char;
                    if (NotDone() && Peek() == '-')
                    {
                        Remove('-');

                        if (NotDone())
                        {
                            var lastPosition = _position;
                            var last = Basic();

                            if (last is Terminal l)
                            {
                                char next = l.Char;

                                if (current > next)
                                {
                                    throw new RegExParsingException("Character range is out of order.", firstsPosition, _position-firstsPosition);
                                }

                                pick.Picks.Add(new Range(new Terminal(current), new Terminal(next)));
                            }
                            else
                            {
                                throw new RegExParsingException("Could not include in range.", lastPosition, 2);
                            }
                        }
                        else
                        {
                            pick.Picks.Add(first);
                            pick.Picks.Add(new Terminal('-'));
                        }
                    }
                    else
                    {
                        pick.Picks.Add(new Terminal(current));
                    }
                }
                else
                {
                    pick.Picks.Add(first);
                }
            }

            if (pick.Picks.Count == 0)
            {
                throw new RegExParsingException($"Unexpected character: \'{Peek()}\' at position {_position}.", _position);
            }

            return pick;
        }

        private RegEx Basic()
        {
            switch (Peek())
            {
                case '\\':
                    Remove('\\');
                    if (!NotDone())
                    {
                        throw new RegExParsingException($"Nothing to escape at {_position}.", _position);
                    }
                    var esc = Pop();
                    switch (esc)
                    {
                        case 'w':
                            return new WordCharacter();
                        case 'W':
                            return new NonWordCharacter();
                        case 'd':
                            return new Digit();
                        case 'D':
                            return new NonDigit();
                        case 's':
                            return new WhiteSpace();
                        case 'S':
                            return new NonWhiteSpace();
                        default:
                            return new Terminal(esc);
                    }
                default:
                    return new Terminal(Pop());
            }
        }

        #endregion
    }

    public class RegExParsingException :Exception
    {
        public int Position { get; set; }
        public int Lenght { get; set; }

        public RegExParsingException(string message, int position, int lenght = 1) : base(message)
        {
            Position = position;
            Lenght = lenght;
        }
    }
}