using System;
using Xamarin.Forms;

namespace ListViewBehaviors.Behavior
{
    public abstract class BaseBehavior<T> : Behavior<T>
        where T : BindableObject
    {
        public T AssociatedObject { get; private set; }

        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);

            // Lors de la construction on définit la propriété AssociatedObject
            AssociatedObject = bindable;

            //Si le contexte est != NULL on initiliase le contexte de du Behavior avec celui de l'objet courant
            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);
            //On se désabonne 
            bindable.BindingContextChanged -= OnBindingContextChanged;

            // Lors de la construction on définit la propriété AssociatedObject
            AssociatedObject = null;
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}
