using System;

abstract class State
{
    //state is the animation to be played
    protected Context _context;

    public void SetContext(Context context)
    {
        this._context = context;
    
    }   

    public abstract void Handle1();

    public abstract void Handle2();
}
