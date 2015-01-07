using System.Collections.Generic;

namespace Prosto_Pets
{
    public class PetLoader : IPetLoader
    {
        IPetLua _petLua;

        public PetLoader(IPetLua petLua)
        {
            _petLua = petLua;
        }

        public void Load(PetPlace[] selectedpets)
        {
            int slot = 1;
            while( slot <= 3 )
            {
                if (slot == 1 && PluginSettings.Instance.LockFirstSlot)
                {
                    Logger.Write(string.Format("Filling pet Slot {0} -- locked", slot));
                }
                else if (slot == 2 && PluginSettings.Instance.LockSecondSlot)
                {
                    Logger.Write(string.Format("Filling pet Slot {0} -- locked", slot));
                }
                else if (slot == 3 && PluginSettings.Instance.LockThirdSlot)
                {
                    Logger.Write(string.Format("Filling pet Slot {0} -- locked", slot));
                }
                else
                {
                    if (selectedpets[slot - 1].opened)
                    {
                        if (selectedpets[slot - 1].opened)
                        {
                            _petLua.LoadPet(slot, selectedpets[slot-1].pet.PetId);
                            Logger.Write(string.Format("Filling pet Slot {0} with {1}", slot, selectedpets[slot-1].pet.ToString()));
                        }
                        else { Logger.Write(string.Format("Filling pet Slot {0} -- nothing selected, unchanged", slot)); }
                    }
                    else { return; }
                }

                slot++;
                
            }
        }
    }
}