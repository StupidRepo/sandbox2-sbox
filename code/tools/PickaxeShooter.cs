namespace Sandbox.Tools
{
	[Library( "tool_pickgun", Title = "Pickaxe Shooter", Description = "Shoot pickaxes", Group = "fun" )]
	public class PickShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootPick();
				}

				if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootPick();
				}
			}
		}

		void ShootPick()
		{
			var ent = new Prop
			{
				Position = Owner.EyePos + Owner.EyeRot.Forward * 50,
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/models/customlol/export_low_poly.obj" );
			ent.Velocity = Owner.EyeRot.Forward * 1000;
		}
	}
}
