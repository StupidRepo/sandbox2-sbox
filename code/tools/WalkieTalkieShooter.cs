namespace Sandbox.Tools
{
	[Library( "tool_wtalkgun", Title = "Walkie Talkie Shooter", Description = "Shoot Walkie Talkies", Group = "fun" )]
	public class PickShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootWalk();
				}

				if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootWalk();
				}
			}
		}

		void ShootWalk()
		{
			var ent = new Prop
			{
				Position = Owner.EyePos + Owner.EyeRot.Forward * 50,
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/custom_props/Walkietalkie/walkietalkie.vmdl" );
			ent.Velocity = Owner.EyeRot.Forward * 1000;
		}
	}
}
