block=1

var iter=AreaService.GetEnumerator();
while(iter.MoveNext()){
	MapEditor.SetBlock(iter.Current,block);
}
