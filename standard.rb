class Worker
  def initialize(inp)
    @in = inp
    @part = []
    @p = 0
    @part[@p] = []
    @rule = {}
    @result = ["cd19900419@hotmail.com\n","\n"] 
  end

  def run
    @in.each do |line|
      if line == "\n"
        @p = @p + 1
        @part[@p] = []
      else
        @part[@p].push(line)
        case @p
        when 0
          a = line.split(' ')
          @rule[a[1]] = a[3]
        when 1
          if (line.include? '+') || (line.include? '-')
            b = line.split(" ")
            c = []
            b.each_with_index do |array,index|
              if array == '+' || array == '-'
                c.push(array)
              elsif !(array =~ /^[a-z]+$/)
                d = array.to_f
                unit = singularize(b[index+1])
                c.push( d * @rule[unit].to_f)
              end
            end
            c = c.join
            c = eval(c)
          else
            b = line.split(' ')
            unit = singularize(b[1])
            c = b[0].to_f * @rule[unit].to_f
          end
          c = format("%.2f",c)
          @result.push(c.to_s+" m\n")
        end
      end
    end 
  @result
  end

  def singularize(s)
      case s
      when 'miles'
        'mile'
      when 'yards'
        'yard'
      when 'inches'
        'inch'
      when 'feet'
        'foot'
      when 'faths'
        'fath'
      when 'furlongs'
        'furlong'
      else
        s
      end
  end

end

File.open("input.txt") do |file|
  new_work = Worker.new(file)
  @result = new_work.run
end

file = File.new("output.txt","w")
@result.each do |r|
  file.puts(r)
end 
