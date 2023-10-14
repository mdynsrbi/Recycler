using System;
using System.IO;
using Fougerite;
using Fougerite.Events;
using Fougerite.Permissions;

namespace Recycler
{
    public class Recycler : Fougerite.Module
    {
        public override string Name { get { return "Recycler"; } }
        public override string Author { get { return "Yasin"; } }
        public override string Description { get { return "Recycler"; } }
        public override Version Version { get { return new Version("1.1"); } }

        public IniParser Settings;
        public IniParser Translations;

        public bool Public;
        public string Sys;

        public string command_usage;
        public string not_enough;
        public string recycled;
        public string permission_denied;

        public override void Initialize()
        {
            CheckConfiguration();

            Hooks.OnCommand += OnCommand;
            Hooks.OnCrafting += OnCrafting;
            Hooks.OnResearch += OnResearch;

            Logger.Log("Recycler Plugin: Successfully loaded!");
        }

        public override void DeInitialize()
        {
            Hooks.OnCommand -= OnCommand;
            Hooks.OnCrafting -= OnCrafting;
            Hooks.OnResearch -= OnResearch;

            Logger.Log("Recycler Plugin: Successfully unloaded!");
        }

        private void OnCommand(Fougerite.Player player, string cmd, string[] args)
        {
            if (cmd.ToLower() == "recycle")
            {
                Translations = new IniParser(Path.Combine(ModuleFolder, "Translations.ini"));
                if (Public || player.Admin || PermissionSystem.GetPermissionSystem().PlayerHasPermission(player, "recycler.use"))
                {
                    if (args.Length <= 1)
                    {
                        player.MessageFrom(Sys, command_usage);
                    }
                    else if (args.Length == 2)
                    {
                        if (player.Inventory.HasItem("Recycle Kit"))
                        {
                            int amount = Convert.ToInt32(args[1]);
                            if (args[0].ToLower() == "woodplanks" || args[0].ToLower() == "wood planks")
                            {
                                string itemname = "Wood Planks";
                                if (player.Inventory.HasItem("Wood Planks", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Planks", amount);
                                    player.Inventory.AddItem("Wood", 10 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "lowqualitymetal" || args[0].ToLower() == "low qualitymetal"
                                || args[0].ToLower() == "lowquality metal" || args[0].ToLower() == "low quality metal")
                            {
                                string itemname = "Low Quality Metal";
                                if (player.Inventory.HasItem("Low Quality Metal", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Low Quality Metal", amount);
                                    player.Inventory.AddItem("Metal Fragments", 15 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "woodceiling" || args[0].ToLower() == "wood ceiling")
                            {
                                string itemname = "Wood Ceiling";
                                if (player.Inventory.HasItem("Wood Ceiling", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Ceiling", amount);
                                    player.Inventory.AddItem("Wood Planks", 6 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "woodpillar" || args[0].ToLower() == "wood pillar")
                            {
                                string itemname = "Wood Pillar";
                                if (player.Inventory.HasItem("Wood Pillar", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Pillar", amount);
                                    player.Inventory.AddItem("Wood Planks", 2 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "woodramp" || args[0].ToLower() == "wood ramp")
                            {
                                string itemname = "Wood Ramp";
                                if (player.Inventory.HasItem("Wood Ramp", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Ramp", amount);
                                    player.Inventory.AddItem("Wood Planks", 5 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "woodstairs" || args[0].ToLower() == "wood stairs")
                            {
                                string itemname = "Wood Stairs";
                                if (player.Inventory.HasItem("Wood Stairs", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Stairs", amount);
                                    player.Inventory.AddItem("Wood Planks", 5 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "woodwall" || args[0].ToLower() == "wood wall")
                            {
                                string itemname = "Wood Wall";
                                if (player.Inventory.HasItem("Wood Wall", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Wall", amount);
                                    player.Inventory.AddItem("Wood Planks", 4 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "woodwindow" || args[0].ToLower() == "wood window")
                            {
                                string itemname = "Wood Window";
                                if (player.Inventory.HasItem("Wood Window", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Window", amount);
                                    player.Inventory.AddItem("Wood Planks", 4 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "wooddoorway" || args[0].ToLower() == "wood doorway")
                            {
                                string itemname = "Wood Doorway";
                                if (player.Inventory.HasItem("Wood Doorway", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Doorway", amount);
                                    player.Inventory.AddItem("Wood Planks", 4 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "woodfoundation" || args[0].ToLower() == "wood foundation")
                            {
                                string itemname = "Wood Foundation";
                                if (player.Inventory.HasItem("Wood Foundation", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Foundation", amount);
                                    player.Inventory.AddItem("Wood Planks", 8 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "metalceiling" || args[0].ToLower() == "metal ceiling")
                            {
                                string itemname = "Metal Ceiling";
                                if (player.Inventory.HasItem("Metal Ceiling", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Ceiling", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 6 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "metalpillar" || args[0].ToLower() == "metal pillar")
                            {
                                string itemname = "Metal Pillar";
                                if (player.Inventory.HasItem("Metal Pillar", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Pillar", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 2 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "metalramp" || args[0].ToLower() == "metal ramp")
                            {
                                string itemname = "Metal Ramp";
                                if (player.Inventory.HasItem("Metal Ramp", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Ramp", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 5 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "metalstairs" || args[0].ToLower() == "metal stairs")
                            {
                                string itemname = "Metal Stairs";
                                if (player.Inventory.HasItem("Metal Stairs", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Stairs", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 5 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "metalwall" || args[0].ToLower() == "metal wall")
                            {
                                string itemname = "Metal Wall";
                                if (player.Inventory.HasItem("Metal Wall", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Wall", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 4 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "metalwindow" || args[0].ToLower() == "metal window")
                            {
                                string itemname = "Metal Window";
                                if (player.Inventory.HasItem("Metal Window", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Window", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 4 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "metaldoorway" || args[0].ToLower() == "metal doorway")
                            {
                                string itemname = "Metal Doorway";
                                if (player.Inventory.HasItem("Metal Doorway", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Doorway", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 4 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                            else if (args[0].ToLower() == "metalfoundation" || args[0].ToLower() == "metal foundation")
                            {
                                string itemname = "Metal Foundation";
                                if (player.Inventory.HasItem("Metal Foundation", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Foundation", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 8 * amount);
                                    player.MessageFrom(Sys, recycled.Replace("{amount}", amount.ToString()).Replace("{itemname}", itemname));
                                }
                                else
                                {
                                    player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                                }
                            }
                        }
                        else
                        {
                            string itemname = "Recycle Kit";
                            player.MessageFrom(Sys, not_enough.Replace("{itemname}", itemname));
                        }
                    }
                }
                else
                {
                    player.MessageFrom(Sys, permission_denied);
                }
            }
        }

        private void OnCrafting(CraftingEvent ce)
        {
            if (ce.ItemName == "Recycle Kit")
            {
                ce.Cancel();
            }
        }

        private void OnResearch(ResearchEvent re)
        {
            if (re.ItemName == "Recycle Kit")
            {
                re.Cancel();
            }
        }

        private void CheckConfiguration()
        {
            if (!File.Exists(Path.Combine(ModuleFolder, "Settings.ini")))
            {
                File.Create(Path.Combine(ModuleFolder, "Settings.ini")).Dispose();
                Settings = new IniParser(Path.Combine(ModuleFolder, "Settings.ini"));

                Settings.AddSetting("Settings", "EveryoneCanUse", "true");
                Settings.AddSetting("Settings", "Sys", "Recycler");
                Settings.Save();
                Logger.Log("Recycler Plugin: new settings file created!");

                CheckConfiguration();
            }
            else if (!File.Exists(Path.Combine(ModuleFolder, "Translations.ini")))
            {
                File.Create(Path.Combine(ModuleFolder, "Translations.ini")).Dispose();
                Translations = new IniParser(Path.Combine(ModuleFolder, "Translations.ini"));

                Translations.AddSetting("Translations", "command_usage", "Usage: /recycle itemname amount");
                Translations.AddSetting("Translations", "not_enough", "You don't have enough {itemname}!");
                Translations.AddSetting("Translations", "recycled", "Successfully recycled {amount} {itemname}!");
                Translations.AddSetting("Translations", "permission_denied", "You don't have permission to use this command!");
                Translations.Save();
                Logger.Log("Recycler Plugin: new translations file created!");

                CheckConfiguration();
            }
            else
            {
                Settings = new IniParser(Path.Combine(ModuleFolder, "Settings.ini"));
                Translations = new IniParser(Path.Combine(ModuleFolder, "Translations.ini"));
                try
                {
                    Public = Settings.GetBoolSetting("Settings", "EveryoneCanUse");
                    Sys = Settings.GetSetting("Settings", "Sys");
                    command_usage = Settings.GetSetting("Translations", "command_usage");
                    not_enough = Settings.GetSetting("Translations", "not_enough");
                    recycled = Settings.GetSetting("Translations", "recycled");
                    permission_denied = Settings.GetSetting("Translations", "permission_denied");
                    Logger.Log("Recycler Plugin: Loaded configuration files");
                }
                catch (Exception ex)
                {
                    Logger.LogError("Recycler Plugin: Detected a problem in the configuration");
                    Logger.Log("ERROR -->" + ex.Message);
                    File.Delete(Path.Combine(ModuleFolder, "Settings.ini"));
                    File.Delete(Path.Combine(ModuleFolder, "Translations.ini"));
                    Logger.LogError("Recycler Plugin: Deleted the old configuration files");

                    CheckConfiguration();
                }
            }
        }
    }
}