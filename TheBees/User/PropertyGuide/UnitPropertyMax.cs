using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.UnitData
{
    public static class UnitPropertyMax
    {
        public static List<Dictionary<PropertyType, int>> MaxValues = new List<Dictionary<PropertyType, int>>()
	    {
		    // Gill
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x0071}, // 0067
				    { PropertyType.Acceleration, 0x0034}, // 0034
				    { PropertyType.SupportGraphicsExt, 0x0092}, // 0092
				    { PropertyType.SupportGraphics, 0x0188}, // 0310
				    { PropertyType.ThrownOpponentSpec, 0x0300}, // 1500
				    { PropertyType.AllCollision, 0x00D8}, // 00D8
				    { PropertyType.Collision1, 0x00B0}, // 00B0
				    { PropertyType.Collision2, 0x0019}, // 0019
				    { PropertyType.Collision3, 0x000C}, // 000C
				    { PropertyType.ThrowCollision, 0x0002}, // 0002
				    { PropertyType.CollisionThrown, 0x0008}, // 0008
				    { PropertyType.AttackCollision, 0x002E}, // 002E
				    { PropertyType.AttackDetails, 0x0023}, // 0022
				    { PropertyType.EnemyCtrl, 0x0016} // 0014
			    }
		    },

		    // Alex
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x00F4}, // 007F
				    { PropertyType.Acceleration, 0x005D}, // 005C
				    { PropertyType.SupportGraphicsExt, 0x0035}, // 0035
				    { PropertyType.SupportGraphics, 0x0039}, // 0072
				    { PropertyType.ThrownOpponentSpec, 0x0C78}, // 0C78
				    { PropertyType.AllCollision, 0x013F}, // 013F
				    { PropertyType.Collision1, 0x00F8}, // 00F8
				    { PropertyType.Collision2, 0x0040}, // 0040
				    { PropertyType.Collision3, 0x001D}, // 001D
				    { PropertyType.ThrowCollision, 0x0019}, // 000C
				    { PropertyType.CollisionThrown, 0x0012}, // 0012
				    { PropertyType.AttackCollision, 0x0054}, // 004E
				    { PropertyType.AttackDetails, 0x0065}, // 0064
				    { PropertyType.EnemyCtrl, 0x001D} // 001B
			    }
		    },

		    // Ryu
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x006C}, // 007A
				    { PropertyType.Acceleration, 0x0043}, // 0043
				    { PropertyType.SupportGraphicsExt, 0x0007}, // 0007
				    { PropertyType.SupportGraphics, 0x0036}, // 006C
				    { PropertyType.ThrownOpponentSpec, 0x01C8}, // 01F8
				    { PropertyType.AllCollision, 0x011B}, // 011B
				    { PropertyType.Collision1, 0x00AC}, // 00AC
				    { PropertyType.Collision2, 0x0025}, // 0025
				    { PropertyType.Collision3, 0x0006}, // 0006
				    { PropertyType.ThrowCollision, 0x0002}, // 0002
				    { PropertyType.CollisionThrown, 0x0006}, // 0006
				    { PropertyType.AttackCollision, 0x0043}, // 0043
				    { PropertyType.AttackDetails, 0x005C}, // 005B
				    { PropertyType.EnemyCtrl, 0x002C} // 002B
			    }
		    },

		    // Yun
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x00EA}, // 007F
				    { PropertyType.Acceleration, 0x0059}, // 0059
				    { PropertyType.SupportGraphicsExt, 0x0014}, // 0014
				    { PropertyType.SupportGraphics, 0x0006}, // 000C
				    { PropertyType.ThrownOpponentSpec, 0x07C8}, // 07C8
				    { PropertyType.AllCollision, 0x018B}, // 018B
				    { PropertyType.Collision1, 0x0101}, // 0101
				    { PropertyType.Collision2, 0x004C}, // 004C
				    { PropertyType.Collision3, 0x0016}, // 0016
				    { PropertyType.ThrowCollision, 0x0003}, // 0003
				    { PropertyType.CollisionThrown, 0x0013}, // 0013
				    { PropertyType.AttackCollision, 0x0078}, // 0078
				    { PropertyType.AttackDetails, 0x00AE}, // 00AD
				    { PropertyType.EnemyCtrl, 0x002A} // 0029
			    }
		    },

		    // Dudley
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x0068}, // 0053
				    { PropertyType.Acceleration, 0x0055}, // 0055
				    { PropertyType.SupportGraphicsExt, 0x0029}, // 0029
				    { PropertyType.SupportGraphics, 0x00B2}, // 0164
				    { PropertyType.ThrownOpponentSpec, 0x0168}, // 0168
				    { PropertyType.AllCollision, 0x0105}, // 0105
				    { PropertyType.Collision1, 0x00BD}, // 00BD
				    { PropertyType.Collision2, 0x0023}, // 0023
				    { PropertyType.Collision3, 0x001E}, // 001E
				    { PropertyType.ThrowCollision, 0x0002}, // 0002
				    { PropertyType.CollisionThrown, 0x0017}, // 0017
				    { PropertyType.AttackCollision, 0x004A}, // 004A
				    { PropertyType.AttackDetails, 0x0076}, // 0075
				    { PropertyType.EnemyCtrl, 0x0029} // 0028
			    }
		    },

		    // Necro
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x0087}, // 007F
				    { PropertyType.Acceleration, 0x0033}, // 0032
				    { PropertyType.SupportGraphicsExt, 0x000A}, // 000A
				    { PropertyType.SupportGraphics, 0x002E}, // 005C
				    { PropertyType.ThrownOpponentSpec, 0x0660}, // 0660
				    { PropertyType.AllCollision, 0x0141}, // 0141
				    { PropertyType.Collision1, 0x00E4}, // 00E4
				    { PropertyType.Collision2, 0x004A}, // 004A
				    { PropertyType.Collision3, 0x001B}, // 001B
				    { PropertyType.ThrowCollision, 0x0006}, // 0006
				    { PropertyType.CollisionThrown, 0x0011}, // 0011
				    { PropertyType.AttackCollision, 0x003C}, // 003A
				    { PropertyType.AttackDetails, 0x005C}, // 005B
				    { PropertyType.EnemyCtrl, 0x0017} // 0016
			    }
		    },

		    // Hugo
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x003D}, // 004B
				    { PropertyType.Acceleration, 0x005F}, // 005C
				    { PropertyType.SupportGraphicsExt, 0x003E}, // 003E
				    { PropertyType.SupportGraphics, 0x0047}, // 008E
				    { PropertyType.ThrownOpponentSpec, 0x0BD0}, // 0BD0
				    { PropertyType.AllCollision, 0x0102}, // 0102
				    { PropertyType.Collision1, 0x008E}, // 008E
				    { PropertyType.Collision2, 0x0033}, // 0033
				    { PropertyType.Collision3, 0x0010}, // 0010
				    { PropertyType.ThrowCollision, 0x000C}, // 000C
				    { PropertyType.CollisionThrown, 0x000C}, // 000C
				    { PropertyType.AttackCollision, 0x0044}, // 0041
				    { PropertyType.AttackDetails, 0x0048}, // 0047
				    { PropertyType.EnemyCtrl, 0x0021} // 0020
			    }
		    },

		    // Ibuki
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x00D5}, // 007F
				    { PropertyType.Acceleration, 0x0092}, // 008E
				    { PropertyType.SupportGraphicsExt, 0x08B6}, // 08B6
				    { PropertyType.SupportGraphics, 0x08EE}, // 11DC
				    { PropertyType.ThrownOpponentSpec, 0x0450}, // 1650
				    { PropertyType.AllCollision, 0x0197}, // 0197
				    { PropertyType.Collision1, 0x0111}, // 0111
				    { PropertyType.Collision2, 0x0058}, // 0058
				    { PropertyType.Collision3, 0x0012}, // 0011
				    { PropertyType.ThrowCollision, 0x000C}, // 000C
				    { PropertyType.CollisionThrown, 0x000D}, // 000D
				    { PropertyType.AttackCollision, 0x0084}, // 0081
				    { PropertyType.AttackDetails, 0x00B7}, // 00B6
				    { PropertyType.EnemyCtrl, 0x0026} // 0024
			    }
		    },

		    // Elena
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x00B0}, // 007E
				    { PropertyType.Acceleration, 0x004D}, // 004A
				    { PropertyType.SupportGraphicsExt, 0x005B}, // 005B
				    { PropertyType.SupportGraphics, 0x005B}, // 00B6
				    { PropertyType.ThrownOpponentSpec, 0x0108}, // 00D8
				    { PropertyType.AllCollision, 0x01D1}, // 01D1
				    { PropertyType.Collision1, 0x018C}, // 018C
				    { PropertyType.Collision2, 0x0085}, // 0085
				    { PropertyType.Collision3, 0x000C}, // 000C
				    { PropertyType.ThrowCollision, 0x0002}, // 0002
				    { PropertyType.CollisionThrown, 0x000A}, // 000A
				    { PropertyType.AttackCollision, 0x005E}, // 005E
				    { PropertyType.AttackDetails, 0x0075}, // 0074
				    { PropertyType.EnemyCtrl, 0x001E} // 001C
			    }
		    },

		    // Oro
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x005F}, // 005E
				    { PropertyType.Acceleration, 0x004B}, // 0049
				    { PropertyType.SupportGraphicsExt, 0x0029}, // 0029
				    { PropertyType.SupportGraphics, 0x0043}, // 0086
				    { PropertyType.ThrownOpponentSpec, 0x06A8}, // 06A8
				    { PropertyType.AllCollision, 0x011F}, // 011F
				    { PropertyType.Collision1, 0x00DA}, // 00DA
				    { PropertyType.Collision2, 0x0042}, // 0042
				    { PropertyType.Collision3, 0x0016}, // 0016
				    { PropertyType.ThrowCollision, 0x000A}, // 000A
				    { PropertyType.CollisionThrown, 0x000D}, // 000D
				    { PropertyType.AttackCollision, 0x0041}, // 003F
				    { PropertyType.AttackDetails, 0x005A}, // 0059
				    { PropertyType.EnemyCtrl, 0x001D} // 0019
			    }
		    },

		    // Yang
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x00FD}, // 007F
				    { PropertyType.Acceleration, 0x0069}, // 0068
				    { PropertyType.SupportGraphicsExt, 0x0014}, // 0014
				    { PropertyType.SupportGraphics, 0x0014}, // 0028
				    { PropertyType.ThrownOpponentSpec, 0x07F8}, // 07F8
				    { PropertyType.AllCollision, 0x0184}, // 0184
				    { PropertyType.Collision1, 0x00F5}, // 00F5
				    { PropertyType.Collision2, 0x004A}, // 004A
				    { PropertyType.Collision3, 0x0017}, // 0017
				    { PropertyType.ThrowCollision, 0x0003}, // 0003
				    { PropertyType.CollisionThrown, 0x0013}, // 0013
				    { PropertyType.AttackCollision, 0x0074}, // 0074
				    { PropertyType.AttackDetails, 0x00A6}, // 00A5
				    { PropertyType.EnemyCtrl, 0x0021} // 0020
			    }
		    },

		    // Ken
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x0094}, // 007E
				    { PropertyType.Acceleration, 0x0048}, // 0045
				    { PropertyType.SupportGraphicsExt, 0x0018}, // 0018
				    { PropertyType.SupportGraphics, 0x002A}, // 0054
				    { PropertyType.ThrownOpponentSpec, 0x0438}, // 0438
				    { PropertyType.AllCollision, 0x0104}, // 0104
				    { PropertyType.Collision1, 0x0096}, // 0096
				    { PropertyType.Collision2, 0x002A}, // 002A
				    { PropertyType.Collision3, 0x0006}, // 0006
				    { PropertyType.ThrowCollision, 0x0002}, // 0002
				    { PropertyType.CollisionThrown, 0x0006}, // 0006
				    { PropertyType.AttackCollision, 0x0048}, // 0048
				    { PropertyType.AttackDetails, 0x0077}, // 0076
				    { PropertyType.EnemyCtrl, 0x0027} // 0026
			    }
		    },

		    // Sean
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x00D4}, // 007B
				    { PropertyType.Acceleration, 0x0073}, // 0073
				    { PropertyType.SupportGraphicsExt, 0x0019}, // 0019
				    { PropertyType.SupportGraphics, 0x0019}, // 0032
				    { PropertyType.ThrownOpponentSpec, 0x0438}, // 0438
				    { PropertyType.AllCollision, 0x0110}, // 0110
				    { PropertyType.Collision1, 0x00A4}, // 00A4
				    { PropertyType.Collision2, 0x0031}, // 0031
				    { PropertyType.Collision3, 0x0007}, // 0007
				    { PropertyType.ThrowCollision, 0x0003}, // 0003
				    { PropertyType.CollisionThrown, 0x001A}, // 0006
				    { PropertyType.AttackCollision, 0x0081}, // 004E
				    { PropertyType.AttackDetails, 0x006A}, // 0068
				    { PropertyType.EnemyCtrl, 0x0027} // 0026
			    }
		    },

		    // Urien
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x0097}, // 0079
				    { PropertyType.Acceleration, 0x0044}, // 003F
				    { PropertyType.SupportGraphicsExt, 0x00BB}, // 00BB
				    { PropertyType.SupportGraphics, 0x0149}, // 0292
				    { PropertyType.ThrownOpponentSpec, 0x0300}, // 0300
				    { PropertyType.AllCollision, 0x00F3}, // 00F3
				    { PropertyType.Collision1, 0x00B7}, // 00B7
				    { PropertyType.Collision2, 0x002C}, // 002C
				    { PropertyType.Collision3, 0x000F}, // 000F
				    { PropertyType.ThrowCollision, 0x0002}, // 0002
				    { PropertyType.CollisionThrown, 0x0009}, // 0009
				    { PropertyType.AttackCollision, 0x0037}, // 0037
				    { PropertyType.AttackDetails, 0x0039}, // 0038
				    { PropertyType.EnemyCtrl, 0x0018} // 0017
			    }
		    },

		    // Akuma
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x0090}, // 007E
				    { PropertyType.Acceleration, 0x0063}, // 005D
				    { PropertyType.SupportGraphicsExt, 0x0022}, // 0022
				    { PropertyType.SupportGraphics, 0x0073}, // 00E6
				    { PropertyType.ThrownOpponentSpec, 0x0300}, // 0300
				    { PropertyType.AllCollision, 0x0119}, // 0119
				    { PropertyType.Collision1, 0x00AA}, // 00AA
				    { PropertyType.Collision2, 0x0031}, // 0031
				    { PropertyType.Collision3, 0x0006}, // 0006
				    { PropertyType.ThrowCollision, 0x0013}, // 0005
				    { PropertyType.CollisionThrown, 0x0006}, // 0006
				    { PropertyType.AttackCollision, 0x0053}, // 004F
				    { PropertyType.AttackDetails, 0x0060}, // 005F
				    { PropertyType.EnemyCtrl, 0x0031} // 0030
			    }
		    },

		    // Shin Akuma
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x006A}, // 005A
				    { PropertyType.Acceleration, 0x0058}, // 0057
				    { PropertyType.SupportGraphicsExt, 0x0009}, // 0009
				    { PropertyType.SupportGraphics, 0x002E}, // 005C
				    { PropertyType.ThrownOpponentSpec, 0x0210}, // 0210
				    { PropertyType.AllCollision, 0x00BF}, // 00BF
				    { PropertyType.Collision1, 0x0083}, // 007E
				    { PropertyType.Collision2, 0x0048}, // 0047
				    { PropertyType.Collision3, 0x001A}, // 001A
				    { PropertyType.ThrowCollision, 0x0003}, // 0003
				    { PropertyType.CollisionThrown, 0x0015}, // 0015
				    { PropertyType.AttackCollision, 0x0046}, // 0046
				    { PropertyType.AttackDetails, 0x0054}, // 0053
				    { PropertyType.EnemyCtrl, 0x0024} // 0022
			    }
		    },

		    // Chun-Li
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x00A3}, // 007F
				    { PropertyType.Acceleration, 0x002F}, // 002F
				    { PropertyType.SupportGraphicsExt, 0x004B}, // 004B
				    { PropertyType.SupportGraphics, 0x004B}, // 0096
				    { PropertyType.ThrownOpponentSpec, 0x0210}, // 10B0
				    { PropertyType.AllCollision, 0x01FF}, // 01FF
				    { PropertyType.Collision1, 0x0192}, // 0192
				    { PropertyType.Collision2, 0x00D8}, // 00D8
				    { PropertyType.Collision3, 0x0009}, // 0009
				    { PropertyType.ThrowCollision, 0x0003}, // 0003
				    { PropertyType.CollisionThrown, 0x0015}, // 0009
				    { PropertyType.AttackCollision, 0x0065}, // 0065
				    { PropertyType.AttackDetails, 0x007C}, // 007B
				    { PropertyType.EnemyCtrl, 0x0028} // 0027
			    }
		    },

		    // Makoto
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x00D1}, // 0068
				    { PropertyType.Acceleration, 0x003A}, // 002F
				    { PropertyType.SupportGraphicsExt, 0x008B}, // 008B
				    { PropertyType.SupportGraphics, 0x00FC}, // 01F8
				    { PropertyType.ThrownOpponentSpec, 0x0708}, // 0708
				    { PropertyType.AllCollision, 0x0168}, // 0168
				    { PropertyType.Collision1, 0x0112}, // 0112
				    { PropertyType.Collision2, 0x005D}, // 005D
				    { PropertyType.Collision3, 0x0014}, // 0014
				    { PropertyType.ThrowCollision, 0x0006}, // 0006
				    { PropertyType.CollisionThrown, 0x0011}, // 0011
				    { PropertyType.AttackCollision, 0x004C}, // 004B
				    { PropertyType.AttackDetails, 0x004E}, // 004D
				    { PropertyType.EnemyCtrl, 0x0022} // 0021
			    }
		    },

		    // Q
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x00FF}, // 007F
				    { PropertyType.Acceleration, 0x0034}, // 0034
				    { PropertyType.SupportGraphicsExt, 0x0012}, // 0012
				    { PropertyType.SupportGraphics, 0x0012}, // 0024
				    { PropertyType.ThrownOpponentSpec, 0x04E0}, // 04E0
				    { PropertyType.AllCollision, 0x01E9}, // 01E9
				    { PropertyType.Collision1, 0x018A}, // 018A
				    { PropertyType.Collision2, 0x00A1}, // 00A1
				    { PropertyType.Collision3, 0x0008}, // 0008
				    { PropertyType.ThrowCollision, 0x0006}, // 0006
				    { PropertyType.CollisionThrown, 0x0006}, // 0006
				    { PropertyType.AttackCollision, 0x0054}, // 0053
				    { PropertyType.AttackDetails, 0x004D}, // 004C
				    { PropertyType.EnemyCtrl, 0x002D} // 002B
			    }
		    },

		    // Twelve
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x008B}, // 0070
				    { PropertyType.Acceleration, 0x003E}, // 0021
				    { PropertyType.SupportGraphicsExt, 0x0085}, // 0085
				    { PropertyType.SupportGraphics, 0x0085}, // 010A
				    { PropertyType.ThrownOpponentSpec, 0x03D8}, // 03D8
				    { PropertyType.AllCollision, 0x01F7}, // 01F7
				    { PropertyType.Collision1, 0x0177}, // 0177
				    { PropertyType.Collision2, 0x0132}, // 0126
				    { PropertyType.Collision3, 0x001F}, // 001F
				    { PropertyType.ThrowCollision, 0x0035}, // 0002
				    { PropertyType.CollisionThrown, 0x0013}, // 0013
				    { PropertyType.AttackCollision, 0x0090}, // 007D
				    { PropertyType.AttackDetails, 0x0068}, // 0067
				    { PropertyType.EnemyCtrl, 0x0019} // 0018
			    }
		    },

		    // Remy
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x0100}, // 007B
				    { PropertyType.Acceleration, 0x003F}, // 003D
				    { PropertyType.SupportGraphicsExt, 0x001F}, // 001F
				    { PropertyType.SupportGraphics, 0x002A}, // 0054
				    { PropertyType.ThrownOpponentSpec, 0x0150}, // 0150
				    { PropertyType.AllCollision, 0x0191}, // 0191
				    { PropertyType.Collision1, 0x0139}, // 0139
				    { PropertyType.Collision2, 0x0084}, // 0084
				    { PropertyType.Collision3, 0x000C}, // 000C
				    { PropertyType.ThrowCollision, 0x0002}, // 0002
				    { PropertyType.CollisionThrown, 0x0007}, // 0007
				    { PropertyType.AttackCollision, 0x004F}, // 004F
				    { PropertyType.AttackDetails, 0x004F}, // 004E
				    { PropertyType.EnemyCtrl, 0x001D} // 001C
			    }
		    },

		    // Missile
		    {
			    new Dictionary<PropertyType, int>()
			    {
				    { PropertyType.TweakMotion, 0x0009}, // 0071
				    { PropertyType.Acceleration, 0x009A}, // 009A
				    { PropertyType.SupportGraphicsExt, 0x0000}, // 0000
				    { PropertyType.SupportGraphics, 0x0000}, // 0000
				    { PropertyType.ThrownOpponentSpec, 0x0000}, // 0000
				    { PropertyType.AllCollision, 0x00D8}, // 00D8
				    { PropertyType.Collision1, 0x006C}, // 0062
				    { PropertyType.Collision2, 0x0001}, // 0001
				    { PropertyType.Collision3, 0x0001}, // 0001
				    { PropertyType.ThrowCollision, 0x0001}, // 0001
				    { PropertyType.CollisionThrown, 0x0001}, // 0001
				    { PropertyType.AttackCollision, 0x00C0}, // 00C0
				    { PropertyType.AttackDetails, 0x006A}, // 0069
				    { PropertyType.EnemyCtrl, 0x002E} // 002D
			    }
		    }

        };

    }
}
