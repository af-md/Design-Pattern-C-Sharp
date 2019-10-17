using System;
using System.Xml.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Adapter
{

    public interface IHumanWizard
    {
        void WeakSpell(string spellType);
    }

    public interface IGoblinWizard
    {
        void StrongSpell(int level);
    }

    public class HumanWizard : IHumanWizard
    {
        public void WeakSpell(string spellType)
        {
            switch (spellType)
            {
                case "weak1":
                    Console.WriteLine("Weak1 Abaracadabra");
                    break;
                case "weak2":
                    Console.WriteLine("Weak1 Abaracadabra");
                    break;
            }
        }
    }

    public class GoblinWizard : IGoblinWizard
        {
            public void StrongSpell(int level)
            {
                switch (level)
                {
                    case 1:
                        Console.WriteLine("Strong 1 Abaracadabra");
                        break;
                    case 2:
                        Console.WriteLine("Strong 2 Abaracadabra");
                        break;

                }
            }
        }

        public class HumanAdapter : HumanWizard
        {
            private IGoblinWizard _goblinWizard;

            public HumanAdapter(IGoblinWizard goblinWizard)
            {
                _goblinWizard = goblinWizard;
            }

            public void StrongSpell(string spellType)
            {
                switch (spellType)
                {
                    case "weak1":
                        _goblinWizard.StrongSpell(1);
                        break;
                    case "weak2":
                        _goblinWizard.StrongSpell(2);
                        break;

                }
            }
        }

        [TestFixture]
        public class AdapterTest
        {
            [Test]
            public void AdapterMethodTest()
            {
                IGoblinWizard dollin = new GoblinWizard();
                IHumanWizard bollin = new HumanWizard();
                var mollin = new HumanAdapter(dollin);


                bollin.WeakSpell("weak1");

                dollin.StrongSpell(1);

                mollin.StrongSpell("weak1");

            }
        }

}
    