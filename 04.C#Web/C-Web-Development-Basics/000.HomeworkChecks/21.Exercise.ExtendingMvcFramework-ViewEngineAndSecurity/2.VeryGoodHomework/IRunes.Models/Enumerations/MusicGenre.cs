using System.ComponentModel;

namespace IRunes.Models.Enumerations
{
    public enum MusicGenre
    {
	Unclassified = 0,
	[DisplayName("Alternative Metal")]
	AlternativeMetal = 1,
	[DisplayName("Alternative Rock")]
	AlternativeRock = 2,
	Blues = 3,
	[DisplayName("Blues Rock")]
	BluesRock = 4,
	Classical = 5,
	Country = 6,
	Dance = 7,
	Disco = 8,
	[DisplayName("Drum & Bass")]
	DrumNBass = 9,
	Dubstep = 10,
	Electro = 11,
	[DisplayName("Electronic Rock")]
	ElectronicRock = 12,
	Europop = 13,
	Folk = 14,
	Funk = 15,
	Grunge = 16,
	Hardcore = 17,
	[DisplayName("Heavy Metal")]
	HeavyMetal = 18,
	[DisplayName("Hip-Hop")]
	HipHop = 19,
	House = 20,
	Industrial = 21,
	[DisplayName("Industrial Metal")]
	IndustrialMetal = 22,
	Jazz = 23,
	[DisplayName("K-Pop")]
	KPop = 24,
	Latin = 25,
	Metal = 26,
	Metalcore = 27,
	Newage = 28,
	Pop = 29,
	[DisplayName("Pop Rock")]
	PopRock = 30,
	[DisplayName("Progressive Metal")]
	ProgressiveMetal = 31,
	[DisplayName("Psychedelic Rock")]
	PsychedelicRock = 32,
	[DisplayName("Punk Rock")]
	PunkRock = 33,
	Reggae = 34,
	Religious = 35,
	Rock = 36,
	Soul = 37,
	Techno = 38,
	Trance = 39,
	Tribal = 40
    }
}
