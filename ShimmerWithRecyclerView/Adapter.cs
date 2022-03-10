using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Supercharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShimmerWithRecyclerView
{
    class MyAdapter : RecyclerView.Adapter
    {
        private FriendsDetails _friendsDetails;
        private Context context;

        public MyAdapter(FriendsDetails friendsDetails, Context context)
        {
            _friendsDetails = friendsDetails;
            this.context = context;
        }

        public override int ItemCount => _friendsDetails.NumbFriends;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyViewHolder viewHolder = holder as MyViewHolder;
            viewHolder.Binddata(_friendsDetails, position);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.list_Item, parent, false);
            return new MyViewHolder(view);
        }
    }
    class MyViewHolder : RecyclerView.ViewHolder
    {
        public ImageView friendImage;
        public TextView friendNameText;
        public TextView friendDescriptionText;
        public ShimmerLayout myShimmerLayout;
        public RelativeLayout relativeLayout2;
        public MyViewHolder(View itemView) : base(itemView)
        {
            friendImage = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            friendNameText = itemView.FindViewById<TextView>(Resource.Id.firendnameText);
            friendDescriptionText = itemView.FindViewById<TextView>(Resource.Id.frienddescriptionText);
            myShimmerLayout = itemView.FindViewById<ShimmerLayout>(Resource.Id.shimmerLayout);
            relativeLayout2 = itemView.FindViewById<RelativeLayout>(Resource.Id.relativeLayout2);

            StartShimmer();
        }
        private async void StartShimmer()
        {
            myShimmerLayout.Visibility = ViewStates.Visible;
            myShimmerLayout.StartShimmerAnimation();
            await StopShimmer();
        }
        private async Task StopShimmer()
        {
            await Task.Delay(5000);
            relativeLayout2.Visibility = ViewStates.Visible;
            myShimmerLayout.Visibility = ViewStates.Invisible;

        }
        internal void Binddata(FriendsDetails friendsDetails, int position)
        {
            friendImage.SetImageResource(friendsDetails[position].PhotoId);
            friendNameText.Text = friendsDetails[position].Fname;
            friendDescriptionText.Text = friendsDetails[position].Fdescription;
        }
    }
}