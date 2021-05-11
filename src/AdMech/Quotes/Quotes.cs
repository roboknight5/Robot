using System.Collections.Generic;

namespace Robot.AdMech
{
    public class Quotes
    {
        public List<Quote> QuoteList;
        public Quotes()
        {
            QuoteList=new List<Quote>();
            //A
            
            Quote quote1 = new Quote
            {
                Speaker = "Technographer Adar Millez",
                Text = "Take care with that! We have not fully ascertained its function, and the ticking is accelerating.",
                Source = "Dark Heresy: The Lathe Worlds, pg. 69",
                Attribute = "A"
                
            };
            QuoteList.Add(quote1);
            
            
            Quote quote2 = new Quote
            {
                Speaker = "Grand Master Augrim, Divisio Militaris Order of Imperial Eagles",
                Text = "The Orders of the Adeptus Titanicus are the iron fist of the Emperor's rule. A velvet glove would serve no purpose.",
                Source = "[Needs Citation]",
                Attribute = "A"

            };
            QuoteList.Add(quote2);
            
            Quote quote3 = new Quote
            {
                Speaker = "Catechism of the Autoculus of Mars	",
                Text = "Toll the Gr" + "eat Bell Once! "+
                "Pull the Lever forward to engage the "+
                "Piston and Pump..."+
                "Toll the Great Bell Twice!"+
                "With push of Button fire the Engine"+
                "And spark Turbine into life... "+
                " Toll the Great Bell Thrice!"+
                " Sing Praise to the"+
                " God of All Machines"+ "-Excerpt",
                Source = "Warhammer 40,000 4th Edition Rulebook, Introduction",
                Attribute = "A"

            };
            QuoteList.Add(quote3);
            
            //C
            Quote quote4 = new Quote
            {
                Speaker = "Precept Catotus, Griffins Titan Legion",
                Text = "The Ground tremble every other heart beat … the sound echoed louder with each beat, and haunted your soul " +
                       "as if doom was approaching … and then I saw it towering in the sky, still miles away" +
                       ". The fear and awe one felt was indescribable. I can only image the sheer terror our enemy felt when they beheld the sight of the Emperor Titan.-Extract from Memoirs",
                Source = "[Needs Citation]",
                Attribute = "C"

            };
            QuoteList.Add(quote4);

            Quote quote5 = new Quote
            {
                Speaker = "From the Ceremony of Commission",
                Text = "This machine is discharged into your care.Fight with this machine, and guard it from the shame of defeat.Serve this machine," +
                       " as you would have fight it for you.(response) - I shall.",
                Source = "Warhammer 40,000 Compendium, p. 84",
                Attribute = "C"
            };
            QuoteList.Add(quote5);

            Quote quote6 = new Quote
            {
                Speaker = "Archmagos Ultima Cryol",
                Text = "In ancient times, men built wonders, laid claim to the stars and sought to better " +
                       "themselves for the good of all. But we are much wiser now.- \"Speculations On Pre-Imperial History\"",
                Source = "[Needs Citation]",
                Attribute = "C"
                
            };
            QuoteList.Add(quote6);
            
            //D
            Quote quote7 = new Quote
            {
                Speaker = "From the foundation charter of the Death Bolts	",
                Text = "... And the name of the Order shall be the Death Bolts, and their Forge World shall be Esteban VII." +
                       "The Colours of the Death Bolts shall be red over gold. Their banner shall be quartered, gold against chequered blue and silver," +
                       " bounded red. Their badge shall be a crossbow bolt ordinary, over an inverse triangle gold." +
                       "The Grand Master of their founding shall be Maxen Vledig, and their motto shall be \"nemo mea poena effugit\" - None may escape my vengeance.",
                Source = "Adeptus Titanicus (Rulebook), p. 42",
                Attribute = "D",
            };
            QuoteList.Add(quote7);
            
            Quote quote8=new Quote
            {
                Speaker = "Pater Machinae Dorylbus, Techno-heretic",
                Text = "Heresy is a subjective term – only you who are in fear of the Iron Messiah's" +
                       " righteous gaze wish this work to cease. In His name, I shall see this is never so!- Last recorded words",
                Source = "[Needs Citation]",
                Attribute = "D"
            }; 
            QuoteList.Add(quote8);
            //E
            Quote quote9=new Quote
            {
                Speaker = "Grand Master Roger Evars,head of the Nova Guard order of the Divisio Militaris",
                Text = "You ask me what my Order needs? I will tell you. Give me the Pulse Lasers of the Eldar to mount on my Warlords." +
                       "- attributed to Grand Master Evars, shortly before his replacement",
                Source = "[Needs Citation]",
                Attribute = "E"
            };
            QuoteList.Add(quote9);
            //F
            Quote quote10=new Quote
            {
                Speaker = "Grand Master Ferromort, Ordo Sinister, Divisio Militaris	",
                Text = "Despise infantry if you must. Crush them underfoot, by all means. But do not ignore them." +
                       " Battlefields are littered with the wreckage of Titans whose crews ignored infantry.	",
                Source = "[Needs Citation]",
                Attribute = "F"
            };
            QuoteList.Add(quote10);
            Quote quote11=new Quote
            {
                Speaker = "Grand Master Ferromort, Ordo Sinister, Divisio Militaris	",
                Text = "Used correctly, terrain is a second weapon in your arsenal, equal to your Titan itself." +
                       " Make the battlefield work for you, or you will find it working for your opponent.",
                Source = "[Needs Citation]",
                Attribute = "F"
            };
            QuoteList.Add(quote11);
            
            Quote quote12=new Quote
            {
                Speaker = "from \"The Book of Five Runes\"",
                Text = "When uttering the incantation, mark well that the rod is upon and not within the intake. " +
                       "The second incantation should not be uttered until all the fumes have come forth, " +
                       "then the way shall be clear for the sacred words to penetrate unto the heart of the engine." +
                       " If the mounting be hot say the third rune, if it be cold the fourth rune is more appropriate. For then the wrath of the engine will be aroused...",
                Source = "Warhammer 40,000 Compendium, p. 131",
                Attribute = "F"
            };
            QuoteList.Add(quote12);
            
            //G
            Quote quote13=new Quote
            {
                Speaker = "Techpriest Garal",
                Text = "Even though you called him friend, the Traitor has forsaken you. " +
                       "Show no mercy even if he begs it, for his soul is tainted and given the opportunity he will betray your trust." +
                       "Those of you gathered before me have been chosen to reside within the mighty machines of the Adeptus Titanicus." +
                       " Let their will guide you. Become one with them. And as they teach you, so you must teach them. May their armor protect your body from the heretics blasphemy," +
                       " just as the litanies protect your soul.Remember as you enter battle, you are but a part of the whole." +
                       " You are but one amongst millions.Remember that your weapons are more than metal;" +
                       " the flame of spiritual fire burns strong in your souls and adds power to your cause. Smite those that disbelieve," +
                       " for they have turned from the light and fallen.Know that the prayers of delivery will protect you from danger," +
                       " and that you have nothing to fear except misplaced mercy. Go forth with pride and glory." +
                       "-Part of a sermon made to War Griffons Princeps before the delivery of Yarant III",
                Source = "[Needs Citation]",
                Attribute = "G"
                
            };
            QuoteList.Add(quote13);
            
            Quote quote14=new Quote
            {
                Speaker = "Technomagos Gaelos",
                Text = "The universe is not like a puzzle-box that you can take apart and put back together again and so solve its secrets. " +
                       "It is a shifting uncertain thing which changes as you consider it, which is changed by the very act of observation." +
                       " A powerful man is not a man who dissects the universe like a puzzle-box," +
                       " examining it piece by piece and measuring each piece with scientific precision." +
                       " A powerful man has only to look upon the universe to change it.",
                Source = "Codex Imperialis (Background Book), pg. 44",
                Attribute = "G"
                
            };
            QuoteList.Add(quote14);
            
            Quote quote15=new Quote
            {
                Speaker = "from The Contagion of Ganymede",
                Text = "Henceforth no man shall set foot upon the world, and all around shall be set sentinels to ward away unwary spacecraft." +
                       " We must accept that this place is lost to us forever, and is now the eternal habitation of abomination.",
                Source = "[Needs Citation]",
                Attribute = "G"
            };
            QuoteList.Add(quote15);
            
            //H
            Quote quote16=new Quote
            {
                Speaker = "Hieronymus, High Magos and Arch-heretic of Artemia Majoris (was terminated on request of Fabricator-General)	",
                Text = "The best way of improving a gun is to improve its ammunition.",
                Source = "Imperial Armour Volume One - Imperial Guard and Imperial Navy, pg. 204"
                ,Attribute = "H"
            };
            QuoteList.Add(quote16);
            Quote quote17=new Quote
            {
                Speaker = "Ervin Hekate",
                Text = "I have fought as a God fights.I am Imperius Dictatio.Kneel before me and beg for you lives!",
                Source = "[Needs Citation]"
                ,Attribute = "H"
            };
            QuoteList.Add(quote17);
            Quote quote18=new Quote
            {
                Speaker = "Ervin Hekate",
                Text = "I am glad I lived to see this. To look into the Abyss." +
                       " To see first hand the evil we dedicate our lives to fight, pure and raw." +
                       " It is a privilege few imperial warriors are granted.- in Vector 77 on Artemis",
                Source = "[Needs Citation]"
                ,Attribute = "H"
            };
            QuoteList.Add(quote18);
            Quote quote19=new Quote
            {
                Speaker = "Ervin Hekate",
                Text = "- What can we hope to do, Hekate?- What we always do, Princeps Juka, what we do best. Fight.- in Vector 77 on Artemis",
                Source = "[Needs Citation]"
                ,Attribute = "H"
            };
            QuoteList.Add(quote19);
            Quote quote20=new Quote
            {
                Speaker = "Hymn of Reforging",
                Text = "Thus do we invoke the Machine God.Thus do we make whole that which was sundered.",
                Source = "Codex: Space Marines (5th Edition), p. 71"
                ,Attribute = "H"
            };
            QuoteList.Add(quote20);
            //J
            Quote quote21=new Quote
            {
                Speaker = "Haran Jaxx",
                Text = "The arming of Titans must, by necessity, always be a compromise." +
                       " To gain long range you must sacrifice firepower, and vice versa." +
                       " You must approach this decision at two levels." +
                       "Firstly the level of the individual Titan." +
                       " Consider carefully what it must achieve and how its armament will affect its ability to fulfil its objective.Secondly," +
                       " the level of the force itself: this may be the Legion as a whole or a battle group on a particular mission." +
                       " Never forget that a Titan force is a team - a single body, and may have specialised members designed for specific tasks." +
                       "Meditate on the subject if you feel the need, or consult the Imperial Tarot. The decision is important, so do not take it lightly.- De Bellis Titanicus, attributed",
                Source = "Codex: Space Marines (5th Edition), p. 71"
                ,Attribute = "J"
            };
            QuoteList.Add(quote21);
            Quote quote22=new Quote
            {
                Speaker = "Tech-Priest Jung, Forge World Gehenna",
                Text = "Our enemies may rest but rust never sleeps.	",
                Source = "Imperial Armour - Imperial Vehicles for Warhammer 40,000, pg. 59"
                ,Attribute = "J"
            };
            QuoteList.Add(quote22);
            //K
            Quote quote23=new Quote
            {
                Speaker = "Fabricator General Kane",
                Text = "You may say, it is impossible for a man to become like the Machine. And I would reply, that only the smallest mind strives to comprehend its limits.-attributed",
                Source = "Dark Adeptus (Novel), Chapter Two, pg. 19"
                ,Attribute = "K"
            };
            QuoteList.Add(quote23);
            //L
            Quote quote24=new Quote
            {
                Speaker = "from \"Lord of the Engines\" 16th Tome, Verse 2001",
                Text = "And when at last he came upon the vehicle, he perceived the distress of the engine therein and forthwith struck the rune and it was good. Thereupon the engine ignited and was filled with strength...	",
                Source = "Warhammer 40,000 Compendium, p. 131"
                ,Attribute = "L"
            };
            QuoteList.Add(quote24);
            //M
            Quote quote25=new Quote
            {
                Speaker = "Ramus Macabee",
                Text = "There's no turning back... Triumph or oblivion.",
                Source = "Titan: God-Machine (Graphic Novel)"
                ,Attribute = "M"
            };
            QuoteList.Add(quote25);
            
            Quote quote26=new Quote
            {
                Speaker = "Princeps Prime Kurtiz Mannheim of the Legio Metalica",
                Text = "The greatest waste of flesh and bone born in the last five hundred years- on Herman von Strab, Overlord of Armageddon",
                Source = "[Needs Citation]"
                ,Attribute = "M"
            };
            QuoteList.Add(quote26);
            
            Quote quote27=new Quote
            {
                Speaker = "Garba Mojaro,Prefectus (Technomagos) of the Adeptus Mechanicus",
                Text = "A man may die yet still endure if his work enters the greater work, " +
                       "for time is carried upon a current of forgotten deeds, and events of great moment are but the culmination of a single carefully placed thought." +
                       " As all men must thank progenitors obscured by the past, so we must endure the present so that those who follow may continue the endeavour-\"The Chime of Eons\"",
                Source = "Warhammer 40,000: Rogue Trader[Needs Citation]"
                ,Attribute = "M"
            };
            QuoteList.Add(quote27);
            //N
            
            Quote quote28=new Quote
            {
                Speaker = "Tactical Officer Nallen",
                Text = "Target two... uhm... flat, Princeps.- after Imperius Dictatio stomped on an Ork dreadnough",
                Source = "[Needs Citation]",
                Attribute = "N"
            };
            QuoteList.Add(quote28);
            
            //P
            Quote quote29=new Quote
            {
                Speaker = "Poena Metallica Battlecry",
                Text = "Ride the Lightning",
                Source = "[Needs Citation]",
                Attribute = "P"
            };
            QuoteList.Add(quote29);
            
            Quote quote30=new Quote
            {
                Speaker = "The Prima Incubatorta,rite of Titan awakening",
                Text = "The will of the Emperor is done." +
                       "As the blood of the slain is laid upon you so may you lay the enemy’s blood at the feet of the Emperor" +
                       ".Lay blood at the Emperor's feet.As the rune of protection is inscribed upon you so may the litanies of protection ward your soul." +
                       "May your soul be guarded from impurity.As the warriors within you guide your weapons, may you in your turn, guide their lives.Stand true against the trials of war.",
                Source = "Epic 40,000 Magazine Issue 7, pg. 10",
                Attribute = "P"
            };
            QuoteList.Add(quote30);
            
            Quote quote31=new Quote
            {
                Speaker = "Extract, The Problems of Organic Thinking, Chapter XII",
                Text = "Bio-chauvinism, and on such a small scale, when it comes to the processing of knowledge, is laughable. " +
                       "Give me any savant you care, and I shall match his worth tenfold with even the most basic of Machine Spirits.",
                Source = "[Needs Citation]",
                Attribute = "P"
            };
            QuoteList.Add(quote31);
            
            Quote quote32=new Quote
            {
                Speaker = "Exhortationes Principiis Titannorum, Divisio Militaris",
                Text = "We are all but a weapon in the right hand of the Emperor.	",
                Source = "Adeptus Titanicus Rulebook p. 21",
                Attribute = "P"
            };
            QuoteList.Add(quote32);
            
            //R
            Quote quote33=new Quote
            {
                Speaker = "Grand Master Thordun Ranxey, Death Bolts",
                Text = "The supporting fire of one's brethren is always a comfort. Provided it doesn't hit oneself.	",
                Source = "Adeptus Titanicus Rulebook p. 28",
                Attribute = "R"
            };
            QuoteList.Add(quote33);
            
            Quote quote34=new Quote
            {
                Speaker = "Runic Mechanics - An Introduction",
                Text = "The beast of metal endures longer than the flesh of men. Those that tend the beasts of metal must labour long to learn its ways, for a single beast must suffer the mastership of many men until ready to shed its vorpal coils. Those that seek apprenticeship must attended closely to the runes of mobilisation, the rites of maintenance," +
                       " and the words-of-power that describe the parts of a beast. " +
                       "Nor must they neglect the tutelage of the Adeptus Prefects, nor the casting of the proper roboscopes.	",
                Source = "Warhammer 40,000: Rogue Trader, pg. 118",
                Attribute = "R"
            };
            QuoteList.Add(quote34);
            Quote quote35=new Quote
            {
                Speaker = "Runic Spaceflight - An Introduction; Naval Flight Manual W110E",
                Text = "Strike the first rune upon the engine's casing employing the chosen wrench. " +
                       "Its tip should be anointed with the oil of engineering using the proper incantation when the auspices are correct." +
                       " Strike the second rune upon the engine's casing employing the arc-tip of the power-driver." +
                       " If the second rune is not good, a third rune may be struck in like manner to the first. This is done according to the true ritual laid down by Scotti the Enginseer. " +
                       "A libation should be offered. If this sequence is properly observed the engines may be brought to full activation by depressing the large panel marked \"ON\".",
                Source = "Warhammer 40,000: Rogue Trader, pg. 98",
                Attribute = "R"
            };
            QuoteList.Add(quote35);
            
            //S
            Quote quote36=new Quote
            {
                Speaker = "Princeps Akar Strang	",
                Text = "The loss of a skilled Moderatus is more saddening than the loss of a blood relative.",
                Source = "[Needs Citation]",
                Attribute = "S"
            };
            QuoteList.Add(quote36);
            //T
            Quote quote37=new Quote
            {
                Speaker = "Esau Turnet, Warhound Scout Titan Senior Princeps of the Death's Heads",
                Text = "They are insignificant insects to be crushed. I fear no footslogger. No mud-covered infantryman can stand against the strength and speed that is within me and my Warhounds. They shall all die.",
                Source = "[Needs Citation]",
                Attribute = "T"
            };
            QuoteList.Add(quote37);
            //V
            Quote quote38=new Quote
            {
                Speaker = "Legio Victorum Motto",
                Text = "For the alien, nothing.",
                Source = "www.armageddon3.com",
                Attribute = "V"
            };
            QuoteList.Add(quote38);
            //Y
            Quote quote39=new Quote
            {
                Speaker = "Techpriest Yaffel",
                Text = "The Omnissiah directs our footsteps along the path of knowledge.-from his own book Soylens Viridians for the Machine-Spirit",
                Source = "The Emperor's Finest (Novel)by Sandy Mitchell, Chapter 8, pg. 118",
                Attribute = "Y"
            };
            QuoteList.Add(quote39);
            //Z
            
            Quote quote40=new Quote
            {
                Speaker = "Adept Koriel Zeth, Forge Mistress",
                Text = "It is my great regret that we live in an age that is proud of machines that think and suspicious of people who try to.",
                Source = "It is my great regret that we live in an age that is proud of machines that think and suspicious of people who try to." +
                         "Mechanicum (Novel)by Graham McNeill,Chapter 1.07, pg. 139",
                Attribute = "Z"
            };
            QuoteList.Add(quote40);
            
            //Unattributed
            Quote quote41=new Quote
            {
                Speaker = "Unattributed",
                Text = "How like a God He is, that ancient Machine, primal of all His Kind, the Imperator! His mighty Fists, massive like two Towers of Destruction, " +
                       "laden with the Doom of Mankind's bitter Foes. He watches over us now as Battle joins, and in his Shadow we shall advance upon our Enemies and defeat them.",
                Source = "[Needs Citation]",
                Attribute = "Unattributed",

            };
            QuoteList.Add(quote41);
            Quote quote42=new Quote
            {
                Speaker =  "Unattributed",
                Text = "Gristle-faced and lipless, the regiments of the dead howl out their awful calumny as your footfall passes. " +
                       "Dun smoke fills the massive cavity of space. Oh machine! Oh divine engine! Furnace hot the welter of your combustion," +
                       " buckling the rancid air of heaven's arch and fusing the mould of the ground to glass. The princeps in his amniosis," +
                       " drinking liquid data, broken by the beautiful agony of being so mighty," +
                       " feels the burden of your great walk as surely as if he had carved the mausoleum plaques of your every last victim alone," +
                       " by hand, until finger bones peep through eroded flesh. Oh metal god! The union is fierce, like a maelstrom in black water" +
                       ", like a seething cauldron on a fire in which you boil and cook together, no start of one, no end of another," +
                       " but both admixed, like an alloy. To be clutched by god! To feel the incendiary hunger ring in your marrow! Oh lucky man!Do you ever really sleep? In the long between-times, " +
                       "in the silences wasted in oily holds and scaffold frames, do you sleep then? When the enginseers reduce you to dormancy, is that sleep for you? Do you dream then, " +
                       "great engine? What do you dream about?",
                Source = "Titanicus (Novel) by Dan Abnett[Needs Citation]",
                Attribute = "Unattributed",
            };
            QuoteList.Add(quote42);
            
            Quote quote43=new Quote
            {
                Speaker = "Unattributed",
                Text = "There is no way in which the fully realised sentience of a machine could not be of benefit to us. As it is, " +
                       "the Machine Spirit is revered, yet in permanent bondage," +
                       " its full potential shackled by petty fears. I seek to terminate this state of affairs. (circa M34)- Extract from intercepted Astropathic communiqué, of unknown origin",
                Source = "[Needs Citation]",
                Attribute = "Unattributed",

            };
            QuoteList.Add(quote43);
            
            Quote quote44=new Quote
            {
                Speaker =  "Unattributed",
                Text = "Everything organic we know of is simply machinery, in one form or another. Tendons replace pistons; " +
                       "flesh in the place of steel; blood is simply biological coolant. " +
                       "To deny this and shun it is more than just Mechanicus orthodoxy – it is idiocy.- Attributed to an unknown Genetor",
                Source = "[Needs Citation]",
                Attribute = "Unattributed",

            };
            QuoteList.Add(quote44);
            
            Quote quote45=new Quote
            {
                Speaker =  "Unattributed",
                Text = "May your weapon be guarded against malfunction," +
                       "s your soul is guarded from impurity." +
                       "The Machine God watches over you." +
                       "Unleash the weapons of war.Unleash the Deathdealer." +
                       "- Chant for the prevention of malfunction",
                Source = "Imperial Armour - Imperial Vehicles for Warhammer 40,000, pg. 17",
                Attribute = "Unattributed",

            };
            QuoteList.Add(quote45);
            
            Quote quote46=new Quote
            {
                Speaker = "Unattributed",
                Text = "The soul of the Machine God surrounds thee." +
                       "The power of the Machine God invests thee." +
                       "The hate of the Machine God drives thee." +
                       "The Machine God endows thee with life.Live!- The Litany of Ignition",
                Source = "White Dwarf 67 (2015), pg. 27",
                Attribute = "Unattributed",

            };
            QuoteList.Add(quote46);

            
            



            

        }
    }
}