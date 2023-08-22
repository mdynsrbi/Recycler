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
        public override Version Version { get { return new Version("1.0"); } }

        public IniParser Settings;

        public bool Public = true;

        public override void Initialize()
        {
            LoadConfig();

            Hooks.OnCommand += OnCommand;
            Hooks.OnResearch += OnResearch;
        }

        public override void DeInitialize()
        {
            Hooks.OnCommand -= OnCommand;
            Hooks.OnResearch -= OnResearch;
        }

        private void OnCommand(Fougerite.Player player, string cmd, string[] args)
        {
            if (cmd.ToLower() == "recycle")
            {
                if (Public == true || player.Admin || PermissionSystem.GetPermissionSystem().PlayerHasPermission(player, "recycler.use"))
                {
                    if (args.Length <= 1)
                    {
                        player.MessageFrom("Recycler", "Usage: /recycle itemname amount");
                    }
                    else if (args.Length == 2)
                    {
                        if (player.Inventory.HasItem("Recycle Kit"))
                        {
                            int amount = Convert.ToInt32(args[1]);
                            if (args[0].ToLower() == "woodplanks" || args[0].ToLower() == "wood planks")
                            {
                                if (player.Inventory.HasItem("Wood Planks", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Planks", amount);
                                    player.Inventory.AddItem("Wood", 10 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Wood Planks");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Wood Planks!");
                                }
                            }
                            else if (args[0].ToLower() == "lowqualitymetal" || args[0].ToLower() == "low qualitymetal"
                                || args[0].ToLower() == "lowquality metal" || args[0].ToLower() == "low quality metal")
                            {
                                if (player.Inventory.HasItem("Low Quality Metal", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Low Quality Metal", amount);
                                    player.Inventory.AddItem("Metal Fragments", 15 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Low Quality Metal");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Low Quality Metal!");
                                }
                            }
                            else if (args[0].ToLower() == "woodceiling" || args[0].ToLower() == "wood ceiling")
                            {
                                if (player.Inventory.HasItem("Wood Ceiling", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Ceiling", amount);
                                    player.Inventory.AddItem("Wood Planks", 6 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Wood Ceiling");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Wood Ceiling!");
                                }
                            }
                            else if (args[0].ToLower() == "woodpillar" || args[0].ToLower() == "wood pillar")
                            {
                                if (player.Inventory.HasItem("Wood Pillar", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Pillar", amount);
                                    player.Inventory.AddItem("Wood Planks", 2 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Wood Pillar");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Wood Pillar!");
                                }
                            }
                            else if (args[0].ToLower() == "woodramp" || args[0].ToLower() == "wood ramp")
                            {
                                if (player.Inventory.HasItem("Wood Ramp", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Ramp", amount);
                                    player.Inventory.AddItem("Wood Planks", 5 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Wood Ramp");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Wood Ramp!");
                                }
                            }
                            else if (args[0].ToLower() == "woodstairs" || args[0].ToLower() == "wood stairs")
                            {
                                if (player.Inventory.HasItem("Wood Stairs", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Stairs", amount);
                                    player.Inventory.AddItem("Wood Planks", 5 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Wood Stairs");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Wood Stairs!");
                                }
                            }
                            else if (args[0].ToLower() == "woodwall" || args[0].ToLower() == "wood wall")
                            {
                                if (player.Inventory.HasItem("Wood Wall", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Wall", amount);
                                    player.Inventory.AddItem("Wood Planks", 4 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Wood Wall");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Wood Wall!");
                                }
                            }
                            else if (args[0].ToLower() == "woodwindow" || args[0].ToLower() == "wood window")
                            {
                                if (player.Inventory.HasItem("Wood Window", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Window", amount);
                                    player.Inventory.AddItem("Wood Planks", 4 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Wood Window");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Wood Window!");
                                }
                            }
                            else if (args[0].ToLower() == "wooddoorway" || args[0].ToLower() == "wood doorway")
                            {
                                if (player.Inventory.HasItem("Wood Doorway", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Doorway", amount);
                                    player.Inventory.AddItem("Wood Planks", 4 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Wood Doorway");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Wood Doorway!");
                                }
                            }
                            else if (args[0].ToLower() == "woodfoundation" || args[0].ToLower() == "wood foundation")
                            {
                                if (player.Inventory.HasItem("Wood Foundation", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Wood Foundation", amount);
                                    player.Inventory.AddItem("Wood Planks", 8 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Wood Foundation");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Wood Foundation!");
                                }
                            }
                            else if (args[0].ToLower() == "metalceiling" || args[0].ToLower() == "metal ceiling")
                            {
                                if (player.Inventory.HasItem("Metal Ceiling", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Ceiling", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 6 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Metal Ceiling");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Metal Ceiling!");
                                }
                            }
                            else if (args[0].ToLower() == "metalpillar" || args[0].ToLower() == "metal pillar")
                            {
                                if (player.Inventory.HasItem("Metal Pillar", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Pillar", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 2 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Metal Pillar");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Metal Pillar!");
                                }
                            }
                            else if (args[0].ToLower() == "metalramp" || args[0].ToLower() == "metal ramp")
                            {
                                if (player.Inventory.HasItem("Metal Ramp", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Ramp", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 5 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Metal Ramp");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Metal Ramp!");
                                }
                            }
                            else if (args[0].ToLower() == "metalstairs" || args[0].ToLower() == "metal stairs")
                            {
                                if (player.Inventory.HasItem("Metal Stairs", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Stairs", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 5 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Metal Stairs");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Metal Stairs!");
                                }
                            }
                            else if (args[0].ToLower() == "metalwall" || args[0].ToLower() == "metal wall")
                            {
                                if (player.Inventory.HasItem("Metal Wall", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Wall", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 4 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Metal Wall");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Metal Wall!");
                                }
                            }
                            else if (args[0].ToLower() == "metalwindow" || args[0].ToLower() == "metal window")
                            {
                                if (player.Inventory.HasItem("Metal Window", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Window", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 4 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Metal Window");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Metal Window!");
                                }
                            }
                            else if (args[0].ToLower() == "metaldoorway" || args[0].ToLower() == "metal doorway")
                            {
                                if (player.Inventory.HasItem("Metal Doorway", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Doorway", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 4 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Metal Doorway");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Metal Doorway!");
                                }
                            }
                            else if (args[0].ToLower() == "metalfoundation" || args[0].ToLower() == "metal foundation")
                            {
                                if (player.Inventory.HasItem("Metal Foundation", amount))
                                {
                                    player.Inventory.RemoveItem("Recycle Kit", 1);
                                    player.Inventory.RemoveItem("Metal Foundation", amount);
                                    player.Inventory.AddItem("Low Quality Metal", 8 * amount);
                                    player.Notice("☢", "Recycled " + amount + " Metal Foundation");
                                }
                                else
                                {
                                    player.Notice("✗", "You don't have enough Metal Foundation!");
                                }
                            }
                        }
                        else
                        {
                            player.Notice("✗", "You don't have Recycle Kit!");
                        }
                    }
                }
            }
        }

        private void OnResearch(ResearchEvent re)
        {
            if (re.ItemName == "Recycle Kit")
            {
                re.Cancel();
            }
        }

        private void LoadConfig()
        {
            if (!File.Exists(Path.Combine(ModuleFolder, "Settings.ini")))
            {
                File.Create(Path.Combine(ModuleFolder, "Settings.ini")).Dispose();
                Settings = new IniParser(Path.Combine(ModuleFolder, "Settings.ini"));

                Settings.AddSetting("Settings", "AllCanUse", "true");
                Logger.Log("Recycler Plugin: New Settings File Created!");
                Settings.Save();

                LoadConfig();
            }
            else
            {
                Settings = new IniParser(Path.Combine(ModuleFolder, "Settings.ini"));
                try
                {
                    Public = Settings.GetBoolSetting("Settings", "AllCanUse");
                    Logger.Log("Recycler Plugin: Settings file Loaded!");
                }
                catch (Exception ex)
                {
                    Logger.LogError("Recycler Plugin: Detected a problem in the configuration");
                    Logger.Log("ERROR -->" + ex.Message);
                    File.Delete(Path.Combine(ModuleFolder, "Settings.ini"));
                    Logger.LogError("Recycler Plugin: Deleted the old configuration file");

                    LoadConfig();
                }
            }
        }
    }
}