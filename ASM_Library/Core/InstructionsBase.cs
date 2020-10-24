

namespace ASM.Core
{
    public abstract class InstructionsBase
    {
        public abstract string MNEMONIC { get; }
        public abstract void Invoke();
    }
}
