namespace upgradejam;

public class MeQuestionMark : Enemy
{

    public MeQuestionMark()
    {
        var s = new Sprite(Game1.GameContent.LoadTexture("textures/spaceship"));
        Scale = Vector2.One * 2f;
        s.Color = Color.MonoGameOrange;
        Sprite = s;
        Health = 100f;
        Rotation = 3.14f;
        points = 50f;
        distance = RNG.Next(0, 2) * 3.14f;
        Speed = RNG.Next(2, 4);

    }

    public override void Initialise()
    {
        if (Position != StartingPosition)
        {
            isApproaching = true;
            CollisionEnabled = false;
        }
        else
        {
            isApproaching = false;
        }
        base.Initialise();
    }

    float distance = 0f;
    float maxDistance = 100f;

    float Speed = 5f;
    public override void Update()
    {
        if (isApproaching)
        {
            //Move position towards ApproachPosition
            Position = Vector2.Lerp(Position, StartingPosition, Speed * Time.DeltaTime);
            if (Vector2.Distance(Position, StartingPosition) < 20f)
            {
                isApproaching = false;
                CollisionEnabled = true;
            }
        }
        else
        {
            distance += Time.DeltaTime * Speed;
            Position.X = StartingPosition.X + (float)Math.Sin(distance) * maxDistance;
        }

        base.Update();

    }

    public override void Render(SpriteBatch batch)
    {
        Sprite.Render(batch);
        base.Render(batch);
    }


}